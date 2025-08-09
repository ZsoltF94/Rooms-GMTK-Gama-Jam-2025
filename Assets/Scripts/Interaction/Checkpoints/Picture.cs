using UnityEngine;

public class Picture : MonoBehaviour, IInteractable
{


    [SerializeField] CheckpointManager checkpointManager;




    [SerializeField] SpriteRenderer sr;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    bool pictureCP = false;


    void Start()
    {

        if (checkpointManager != null) InitializeState();

    }

    public void Interact()
    {
        // turn upside down
        sr.flipY = !sr.flipY;
        // toggle condition
        pictureCP = !pictureCP;
        // toggle CheckpointManager
        checkpointManager.ActivateCheckpoint("pictureCP");
        PlayAudioClip();
    }

    public void InitializeState()
    {
        pictureCP = checkpointManager.checkpoints["pictureCP"];
        sr.flipY = checkpointManager.checkpoints["pictureCP"];
    }

    private void PlayAudioClip()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
