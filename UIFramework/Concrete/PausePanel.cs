using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : BasePanel
{

    static readonly string panelpath = "Prefabs/UI/Panel/PausePanel";
    public PausePanel() : base(new UIType(panelpath))
    {
    }

    private bool isPause=false;


    public override void OnEnter()
    {
        //Gameobject.Find()
        UITool.GetOrAddChildGameObject<Button>("GameExitButton").onClick.AddListener(
            () =>
            {
                //GameObject gameManager = GameObject.Find("gameManager");
                GameRoot.Instance.scene2sceneMsgManager.GetComponent<MainSceneMsg>().MainSceneExitDispatch();
                //gameManager.GetComponent<MainSceneMsg>().MainSceneExitDispatch();

                Debug.Log($"已经找到{GameRoot.Instance.scene2sceneMsgManager.name}，并且分发消息");
                Debug.Log("点击了退出");
                GameRoot.Instance.SceneSystem.SetScene(new StartScence());
            }
        );

        UITool.GetOrAddChildGameObject<Button>("PauseButton").onClick.AddListener(
            () =>
            {
                GameObject gameManager = GameObject.Find("gameManager");

                if (!isPause)
                {
                    gameManager.GetComponent<MainGameManager>().PauseDispatch();
                    Debug.Log("点击了暂停");
                    isPause = true;
                }
                else 
                {
                    gameManager.GetComponent<MainGameManager>().ResumeDispatch();
                    Debug.Log("继续了游戏");
                    isPause = false;
                }
                
            }
        );
    }
}
