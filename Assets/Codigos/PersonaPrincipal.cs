using UnityEngine;

public class PersonaPrincipal : MonoBehaviour
{

    CharacterController controller;

    float walkSpeed = 3f;      // Velocidade andando
    float runSpeed = 6f;       // Velocidade correndo
    float gravity = -20f;
    float verticalVelocity = 0f;

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
        float forwardInput = Input.GetAxisRaw("Vertical");
        float strafeInput = Input.GetAxisRaw("Horizontal");

        // Detectar se Shift est� pressionado
        bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        // Escolher velocidade baseada no Shift
        float currentSpeed = isRunning ? runSpeed : walkSpeed;

        Vector3 forward = transform.forward * forwardInput * currentSpeed;
        Vector3 strafe = transform.right * strafeInput * currentSpeed;

        // Gravidade simplificada
        if (controller.isGrounded)
        {
            verticalVelocity = -1f;
        }
        else
        {
            verticalVelocity += gravity * Time.deltaTime;
        }

        Vector3 movement = forward + strafe;
        movement.y = verticalVelocity;

        controller.Move(movement * Time.deltaTime);
    }
}