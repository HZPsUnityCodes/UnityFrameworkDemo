using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetPanel : BasePanel
{
    static readonly string panelpath = "Prefabs/UI/Panel/SettingPanel";
    public SetPanel() : base(new UIType(panelpath))
    {
    }

    public override void OnEnter()
    {
        UITool.GetOrAddChildGameObject<Button>("ExitButton").onClick.AddListener(
            () =>
            {
                //µã»÷ÊÂ¼þs
                PanelManager.Pop();
             }
        );
    }
}
