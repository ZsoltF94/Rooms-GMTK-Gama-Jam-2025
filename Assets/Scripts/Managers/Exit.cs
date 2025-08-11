

using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private string targetScene;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Timer timer;
    [SerializeField] CheckpointManager checkpointManager;
    [SerializeField] DialogData dialogData;

    [Header("Conditions to enter")]
    [SerializeField] bool lightCP;
    [SerializeField] bool pictureCP;
    [SerializeField] bool crackCP;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioCilpLockerOpen;
    [SerializeField] AudioClip audioClipLockerLocked;

    void Update()
    {
        LockerSound();
    }





    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") // if all checkpoints are as the conditions
            && checkpointManager.checkpoints["lightCP"] == lightCP
            && checkpointManager.checkpoints["pictureCP"] == pictureCP
            && checkpointManager.checkpoints["crackCP"] == crackCP)
        {
            GameManager.Instance.spawnPosition = spawnPosition;
            GameManager.Instance.currentTime = timer.GetCurrentTime();
            GameManager.Instance.SaveCurrentSceneState(checkpointManager);
            SceneTransitionManager.Instance.TransitionToScene(targetScene);
        }
        else if(collision.CompareTag("Player") // if all checkpoints are as the conditions
            && (checkpointManager.checkpoints["lightCP"] != lightCP
            || checkpointManager.checkpoints["pictureCP"] != pictureCP
            || checkpointManager.checkpoints["crackCP"] != crackCP))
        {
            DialogManager.Instance.StartDialog(dialogData.GetLines());
        }
    }

    public void LockerSound()
    {
        if (checkpointManager.checkpoints["lightCP"] == lightCP
            && checkpointManager.checkpoints["pictureCP"] == pictureCP
            && checkpointManager.checkpoints["crackCP"] == crackCP
            && checkpointManager.checkpoints["doorOpen"] == false)
        {
            audioSource.PlayOneShot(audioCilpLockerOpen);
            checkpointManager.checkpoints["doorOpen"] = true;
        }
        if ((checkpointManager.checkpoints["lightCP"] != lightCP
            || checkpointManager.checkpoints["pictureCP"] != pictureCP
            || checkpointManager.checkpoints["crackCP"] != crackCP)
            && checkpointManager.checkpoints["doorOpen"] == true)
        {
            audioSource.PlayOneShot(audioClipLockerLocked);
            checkpointManager.checkpoints["doorOpen"] = false;
        }
        Debug.Log(checkpointManager.checkpoints["doorOpen"]);
    }

}