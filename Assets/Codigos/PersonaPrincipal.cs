using UnityEngine;

public class PersonaPrincipal : MonoBehaviour
{
    CharacterController controller;

    float walkSpeed = 1f;      // Velocidade andando
    float runSpeed = 2f;       // Velocidade correndo
    float gravity = -20f;
    float verticalVelocity = 0f;

    // Propriedade pública para outros scripts acessarem
    public bool IsRunning { get; private set; }
    public bool IsMoving { get; private set; }

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (controller == null)
        {
            Debug.LogError("ERRO: CharacterController não encontrado no GameObject '" + gameObject.name + "'. Adicione o componente!", this);
        }
    }

    void Update()
    {
        if (controller == null)
            return;

        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // Detectar se Shift está pressionado
        IsRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Detectar se está se movendo
        IsMoving = forwardInput != 0 || strafeInput != 0;

        // Escolher velocidade baseada no Shift
        float currentSpeed = IsRunning ? runSpeed : walkSpeed;

        // Criar vetor de movimento horizontal
        Vector3 movement = (transform.forward * forwardInput) + (transform.right * strafeInput);

        // ✅ NORMALIZAR para evitar movimento mais rápido na diagonal
        if (movement.magnitude > 1f)
        {
            movement.Normalize();
        }

        // Aplicar velocidade
        movement *= currentSpeed;

        // Gravidade simplificada
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }
}