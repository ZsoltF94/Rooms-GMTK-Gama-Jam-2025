

using System.Timers;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Timer timer;

    [Header("Checkpoints")]
    [SerializeField] LightSwitch lightSwitch;
    [SerializeField] Picture picture;
    [SerializeField] Crack crack;
    
    [Header("Checkpoint Manager")]
    public CheckpointManager checkpointManager;




    void Start()
    {
        // set time = currentTime
        if (GameManager.Instance.currentTime != null)
        {
            timer.SetCurrentTime(GameManager.Instance.currentTime);
        }

        if (player != null)
        {
            player.transform.position = GameManager.Instance.spawnPosition;
        }

        GameManager.Instance.LoadCurrentSceneState(checkpointManager);
        lightSwitch.InitializeState();
        picture.InitializeState();
        crack.InitializeState();
    }
}