using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScence : ScenesState
{
    readonly string sceneName = "StartScene";
    PanelManager panelManager;

    public override void OnEnter()
    {
        panelManager = new PanelManager();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoader;
        }
        else {
            panelManager.Push(new StartPanel());
        }
    }


    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoader;
    }

    private void SceneLoader(Scene scene, LoadSceneMode load)
    {
        panelManager.Push(new StartPanel());
        Debug.Log($"{sceneName}≥°æ∞º”‘ÿÕÍ±œ£° ");
    }
}

