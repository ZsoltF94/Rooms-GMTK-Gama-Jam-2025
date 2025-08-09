using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip[] footSteps;
    [SerializeField] float stepIntervall;
    PlayerMovement playerMovement;
    float stepTimer = 0f;
    int index;
    int lastIndex;

    Rigidbody2D rb;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (playerMovement.GetMoveInput() != Vector2.zero && !GameManager.Instance.transitionActive)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0)
            {
                PlayFootStep();
                stepTimer = stepIntervall;
            }
            
        }
    }

    void PlayFootStep()
    {
        if (footSteps == null) return;
        index = Random.Range(0, footSteps.Length);
        if (index == lastIndex) index = (index + 1) % footSteps.Length;

        audioSource.PlayOneShot(footSteps[index]);

        lastIndex = index;
    }


}
