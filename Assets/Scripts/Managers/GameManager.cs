

using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    public bool transitionActive = false;
    public bool playerCanMove = true;
    public bool npcsCanMove = true;

    public DateTime currentTime;
    public Vector3 spawnPosition = Vector3.zero;

    [Header("Audio")]
    AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        audiosource.Play();
        currentTime = new DateTime(1, 1, 1, 7, 0, 0);
    }

    //_________________SceneStates

    // save a sceneState for every scene. string = Scene Name = key
    // prepairing a dictionary
    public Dictionary<string, SceneState> sceneStates = new Dictionary<string, SceneState>();

    // saving current SceneState
    public void SaveCurrentSceneState(CheckpointManager checkpointManager)
    {
        // get active Scene
        string currentScene = SceneManager.GetActiveScene().name;

        // if there is no sceneState for this scene, create new
        if (!sceneStates.ContainsKey(currentScene))
        {
            sceneStates.Add(currentScene, new SceneState());
        }
        // get sceneStates of this scene
        SceneState state = sceneStates[currentScene];

        // save all checkpoint values from checkpointManager Dictionary
        // in SceneState dictionary
        foreach (var checkpoint in checkpointManager.checkpoints)
        {
            state.checkpointState[checkpoint.Key] = checkpoint.Value;
        }


    }

    public void LoadCurrentSceneState(CheckpointManager checkpointManager)
    {
        // get active scene
        string currentScene = SceneManager.GetActiveScene().name;

        // if there is no states for this scene, return
        if (!sceneStates.ContainsKey(currentScene))
        {

            return;
        }

        SceneState state = sceneStates[currentScene];
        var checkpointKeys = new List<string>(checkpointManager.checkpoints.Keys);

        // go through every Checkpoint in ChekpointManager 
        // and give the value of the current scene
        foreach (var checkpoint in checkpointKeys)
        {
            if (state.checkpointState.ContainsKey(checkpoint))
            {
                checkpointManager.checkpoints[checkpoint] = state.checkpointState[checkpoint];
            }
        }

    }

    public void ResetAllSceneStates()
    {
        sceneStates.Clear();
        LoopCounter.Instance.IncreaseLoopCounter();
    }



}