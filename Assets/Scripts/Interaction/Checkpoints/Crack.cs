using System.Collections;
using UnityEngine;

public class Crack : MonoBehaviour, IInteractable
{
    [SerializeField] SpriteRenderer sr;
    [SerializeField] CheckpointManager checkpointManager;


    [Header("Toggled Crack Sprites")]
    [SerializeField] Sprite sprite1;
    [SerializeField] Sprite sprite2;

    [Header("Sound")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    bool interacted = false;


    void Start()
    {
        if (checkpointManager != null) InitializeState();
    }

    public void Interact()
    {
        if (interacted) return;

        interacted = true;
        checkpointManager.ActivateCheckpoint("crackCP");
        sr.sprite = sprite1;
        StartCoroutine(ChangeSprite());
        PlayAudioClip();
  
    }

    IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(0.5f);
        sr.sprite = sprite2;
    }

    public void InitializeState()
    {
        interacted = checkpointManager.checkpoints["crackCP"];
        if (interacted)
        {
            sr.sprite = sprite2;
        }
    }

    private void PlayAudioClip()
    {
        audioSource.PlayOneShot(audioClip);
    }
}
