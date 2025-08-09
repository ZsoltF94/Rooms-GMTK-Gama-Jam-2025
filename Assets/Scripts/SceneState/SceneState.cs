

using System;
using System.Collections.Generic;

[System.Serializable]
public class SceneState
{
    public Dictionary<string, bool> checkpointState = new Dictionary<string, bool>();
    public DateTime sceneTime = new DateTime(1, 1, 1, 0, 0, 0);
}