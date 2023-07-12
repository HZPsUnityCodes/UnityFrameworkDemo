using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScence : ScenesState
{
    readonly string sceneName = "MainScence";
    PanelManager panelManager;
    // Start is called before the first frame update
    public override void OnEnter()
    {
        panelManager = new PanelManager();
        if (SceneManager.GetActiveScene().name != sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.sceneLoaded += SceneLoader;
        }
        else
        {
            panelManager.Push(new StartPanel());
        }
    }

    public override void OnExit()
    {
        SceneManager.sceneLoaded -= SceneLoader;
        panelManager.PopAll();
    }

    private void SceneLoader(Scene scene, LoadSceneMode load)
    {
        
        panelManager.Push(new PausePanel());
        Debug.Log($"{sceneName}≥°æ∞º”‘ÿÕÍ±œ!");
    }





}
