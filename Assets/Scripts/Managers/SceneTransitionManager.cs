using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransitionManager : Singleton<SceneTransitionManager>
{


    [SerializeField] Image blackScreen;
    [SerializeField] float fadeDuration;


    // call this from an exit/entry gameObject like a door and add in the target scene 
    public void TransitionToScene(string sceneName)
    {
        // deactivate everything
        GameManager.Instance.transitionActive = true;
        StartCoroutine(FadeAndLoad(sceneName));
    }
    private IEnumerator FadeAndLoad(string sceneName)
    {
        yield return StartCoroutine(Fade(1));
        SceneManager.sceneLoaded += OnLoadedScene;
        SceneManager.LoadScene(sceneName);

    }

    private void OnLoadedScene(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnLoadedScene;
        StartCoroutine(FadeAndEnablePlayer());
    }

    private IEnumerator FadeAndEnablePlayer()
    {
        yield return StartCoroutine(Fade(0));
        // activate everything
        GameManager.Instance.transitionActive = false;
    }

    private IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = blackScreen.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime; // time starts at 0 and goes on by time
            float currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration); // increase currentAlpha
            blackScreen.color = new Color(0, 0, 0, currentAlpha); // create new color wit new currentAlpha
            yield return null; // wait for a frame
        }
    }


}
