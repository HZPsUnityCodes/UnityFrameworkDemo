using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePanel 
{ 
    public UIType UIType { get; private set; }
    public UITool UITool { get; private set; }

    public PanelManager PanelManager { get; private set; }

    public UIManager UIManager { get; private set; }

    /// <summary>
    /// ��ʹ�ó�ʼ������
    /// </summary>
    /// <param name="uiType"></param>
    public BasePanel(UIType uiType) {
        UIType = uiType;
    }
    public void Initialize(UITool tool)
    {
        UITool = tool;
    }

    //��ʼ����������
    public void Initialize(PanelManager panelManager)
    {
        PanelManager = panelManager;
    }

    public void Initialize(UIManager uiManager)
    {
        UIManager = uiManager;
    }


    public virtual void OnEnter() { }

    public virtual void OnPause() {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public virtual void OnResume() {
        UITool.GetOrAddComponent<CanvasGroup>().blocksRaycasts = true;
    }

    public virtual void OnExit() {
        UIManager.DestoryUI(UIType);
    }

    
}