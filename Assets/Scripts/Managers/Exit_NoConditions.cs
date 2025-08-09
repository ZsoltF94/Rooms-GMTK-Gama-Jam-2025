using UnityEngine;

public class Exit_NoConditions : MonoBehaviour
{
    [SerializeField] private string targetScene;
    [SerializeField] Vector3 spawnPosition;
    [SerializeField] Timer timer;
    [SerializeField] CheckpointManager checkpointManager;





    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.spawnPosition = spawnPosition;
            GameManager.Instance.currentTime = timer.GetCurrentTime();
            GameManager.Instance.SaveCurrentSceneState(checkpointManager);
            SceneTransitionManager.Instance.TransitionToScene(targetScene);
        }
    }
}
