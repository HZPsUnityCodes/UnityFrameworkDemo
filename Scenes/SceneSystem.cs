using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSystem
{
    ScenesState sceneState;

    public void SetScene(ScenesState state)
    { 
        if (sceneState != null)
            sceneState.OnExit();
        sceneState = state;

        if (sceneState != null)
            sceneState.OnEnter();
    }

}
