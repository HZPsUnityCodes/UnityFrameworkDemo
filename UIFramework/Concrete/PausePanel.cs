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

                Debug.Log($"�Ѿ��ҵ�{GameRoot.Instance.scene2sceneMsgManager.name}�����ҷַ���Ϣ");
                Debug.Log("������˳�");
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
                    Debug.Log("�������ͣ");
                    isPause = true;
                }
                else 
                {
                    gameManager.GetComponent<MainGameManager>().ResumeDispatch();
                    Debug.Log("��������Ϸ");
                    isPause = false;
                }
                
            }
        );
    }
}
