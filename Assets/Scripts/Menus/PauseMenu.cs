using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenuCanvas;
    private bool isActive = false;

    void Awake()
    {
        pauseMenuCanvas.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isActive = !isActive;
        Time.timeScale = isActive ? 0f : 1f;
        pauseMenuCanvas.SetActive(isActive);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        isActive = !isActive;
        pauseMenuCanvas.SetActive(false);
    }

    public void ExitGame()
    {
        #if !Unity_WEBGL
            Application.Quit();
        #endif
    }
}
