
using System.Collections.Generic;
using UnityEngine;


public class CheckpointManager : MonoBehaviour
{


    public Dictionary<string, bool> checkpoints = new Dictionary<string, bool>();

    void Awake()
    {
        checkpoints.Add("lightCP", false);
        checkpoints.Add("pictureCP", false);
        checkpoints.Add("crackCP", false);
        checkpoints.Add("doorOpen", false);
    }

    public void ActivateCheckpoint(string checkpointname)
    {
        if (checkpoints.ContainsKey(checkpointname))
        {
            checkpoints[checkpointname] = !checkpoints[checkpointname];
        }
    }


}
