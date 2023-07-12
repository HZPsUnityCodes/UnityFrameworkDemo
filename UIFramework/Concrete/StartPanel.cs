using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// �����
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
                //����¼�s
                Debug.Log("StartPlayButton was Clicked!");
                PanelManager.Push(new SetPanel());
            }
            );

        UITool.GetOrAddChildGameObject<Button>("StartPlayButton").onClick.AddListener(
            () => {
                //����¼�s
                GameRoot.Instance.SceneSystem.SetScene( new MainScence() );
            }
            );

        UITool.GetOrAddChildGameObject<Button>("ContinueButton").onClick.AddListener(
            () => {
                //����¼�s
                GameRoot.Instance.SceneSystem.SetScene(new MainScence());
                GameRoot.Instance.isReadOp = true;
                Debug.Log("�ı�isReadOp");
                //GameRoot.Instance.scene2sceneMsgManager.GetComponent<MainSceneMsg>().MainSceneLoadDispatch();
                //Debug.Log($"{GameRoot.Instance.scene2sceneMsgManager.name}�Ѿ������� ��ȡ��Ϣ������");
            }
            );
    }
}
