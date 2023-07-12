using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 主面板
public class StartPanel : BasePanel
{
    // Start is called before the first frame update

    static readonly string path = "Prefabs/UI/Panel/StartPanel";
    public StartPanel() : base(new UIType(path))
    { 
        
    }

    public override void OnEnter()
    {
        UITool.GetOrAddChildGameObject<Button>("SettingButton").onClick.AddListener(
            () =>  {
                //点击事件s
                Debug.Log("StartPlayButton was Clicked!");
                PanelManager.Push(new SetPanel());
            }
            );

        UITool.GetOrAddChildGameObject<Button>("StartPlayButton").onClick.AddListener(
            () => {
                //点击事件s
                GameRoot.Instance.SceneSystem.SetScene( new MainScence() );
            }
            );

        UITool.GetOrAddChildGameObject<Button>("ContinueButton").onClick.AddListener(
            () => {
                //点击事件s
                GameRoot.Instance.SceneSystem.SetScene(new MainScence());
                GameRoot.Instance.isReadOp = true;
                Debug.Log("改变isReadOp");
                //GameRoot.Instance.scene2sceneMsgManager.GetComponent<MainSceneMsg>().MainSceneLoadDispatch();
                //Debug.Log($"{GameRoot.Instance.scene2sceneMsgManager.name}已经发送完 读取消息！！！");
            }
            );
    }
}
