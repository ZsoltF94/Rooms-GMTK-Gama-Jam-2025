using UnityEngine;

public class Restart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void RestartGame()
    {
            GameManager.Instance.spawnPosition = Vector2.zero;
            GameManager.Instance.currentTime = new System.DateTime(1, 1, 1, 7, 0, 0);
            SceneTransitionManager.Instance.TransitionToScene("00");

            // reset SceneState
            GameManager.Instance.ResetAllSceneStates();
    }
}
