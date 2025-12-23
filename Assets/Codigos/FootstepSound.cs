using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource passosAudio;
    public PersonaPrincipal personaScript;  // Referência ao script do personagem
    public float walkStepInterval = 0.5f;   // Intervalo entre passos ao andar
    public float runStepInterval = 0.42f;    // Intervalo entre passos ao correr

    float stepTimer = 0f;

    void Start()
    {
        // Tentar pegar automaticamente se não foi atribuído
        if (personaScript == null)
        {
            personaScript = GetComponent<PersonaPrincipal>();
        }

        if (personaScript == null)
        {
            Debug.LogError("ERRO: PersonaPrincipal não encontrado! Arraste o script no Inspector.", this);
        }
    }

    void Update()
    {
        if (personaScript == null || passosAudio == null)
            return;

        // Verificar se está se movendo
        if (personaScript.IsMoving)
        {
            // Determinar intervalo baseado se está correndo ou andando
            float currentInterval = personaScript.IsRunning ? runStepInterval : walkStepInterval;

            // Atualizar timer
            stepTimer += Time.deltaTime;

            // Tocar som quando o timer atinge o intervalo
            if (stepTimer >= currentInterval)
            {
                passosAudio.PlayOneShot(passosAudio.clip);
                stepTimer = 0f;  // Resetar timer
            }
        }
        else
        {
            // Resetar timer quando parado
            stepTimer = 0f;
        }
    }
}