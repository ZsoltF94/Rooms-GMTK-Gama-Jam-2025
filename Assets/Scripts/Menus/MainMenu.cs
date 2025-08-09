using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string targetScene;

    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;

    public bool lastState;

 

    void Update()
    {
        if (GameManager.Instance.transitionActive != lastState)
        {
            lastState = GameManager.Instance.transitionActive;
            SetButtons(!lastState);
        }
    }
    public void StartGame()
    {
        SceneTransitionManager.Instance.TransitionToScene(targetScene);
    }

    public void ExitGame()
    {
        #if !Unity_WEBGL
            Application.Quit();
        #endif
    }

    private void SetButtons(bool lastState)
    {
        startButton.interactable = lastState;
        exitButton.interactable = lastState;
    }


}
