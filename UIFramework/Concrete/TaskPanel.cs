using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskPanel : BasePanel
{
    static readonly string panelpath = "Prefabs/UI/Panel/PausePanel";
    public TaskPanel() : base(new UIType(panelpath))
    {
    }
    public override void OnEnter()
    {
        UITool.GetOrAddChildGameObject<Button>("GameExitButton").onClick.AddListener(
            () =>
            {
                Debug.Log("������˳�");
                GameRoot.Instance.SceneSystem.SetScene(new StartScence());
            }
        );

        UITool.GetOrAddChildGameObject<Button>("PauseButton").onClick.AddListener(
            () =>
            {

                Debug.Log("�������ͣ");
            }
        );
    }
}
