using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject[] roomLight;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] CheckpointManager checkpointManager;

    [Header("Sprites")]
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Sprite lightOnSprite;
    [SerializeField] Sprite lightOffSprite;


    bool lightCP = false;

    void Start()
    {
        foreach (var light in roomLight)
        {
            //light.SetActive(!lightCP);
            light.GetComponent<Light2D>().enabled = !lightCP;
        }

        if (checkpointManager != null) InitializeState();
        sr.sprite = lightCP ? lightOffSprite : lightOnSprite;
        
    }

    public void Interact()
    {

        lightCP = !lightCP;
        foreach (var light in roomLight)
        {
            //light.SetActive(!lightCP);   
            light.GetComponent<Light2D>().enabled = !lightCP;
        }
               
        checkpointManager.ActivateCheckpoint("lightCP");
        sr.sprite = lightCP ? lightOffSprite : lightOnSprite;        
        PlaySwitchSound();

    }



    public void PlaySwitchSound()
    {
        audioSource.PlayOneShot(audioClip);
    }

    public void InitializeState()
    {
        lightCP = checkpointManager.checkpoints["lightCP"];
        foreach (var light in roomLight)
        {
            //light.SetActive(!lightCP);
            light.GetComponent<Light2D>().enabled = !lightCP;
        }
        
    }
}
