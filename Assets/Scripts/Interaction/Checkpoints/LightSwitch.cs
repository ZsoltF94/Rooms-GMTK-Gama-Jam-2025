using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightSwitch : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject[] roomLight;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;
    [SerializeField] CheckpointManager checkpointManager;

    bool lightCP = false;

    void Start()
    {
        foreach (var light in roomLight)
        {
            //light.SetActive(!lightCP);
            light.GetComponent<Light2D>().enabled = !lightCP;
        }
        
        if(checkpointManager != null) InitializeState();
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
