

using UnityEngine;

public class Exit : MonoBehaviour
{
    [SerializeField] private string targetScene;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Timer timer;
    [SerializeField] CheckpointManager checkpointManager;

    [Header("Conditions to enter")]
    [SerializeField] bool lightCP;
    [SerializeField] bool pictureCP;
    [SerializeField] bool crackCP;





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
    }

}