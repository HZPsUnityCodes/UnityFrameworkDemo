using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMsgPanel : MonoBase
{

    private Text healthtText;
    private Text valuetext;


    private void Awake()
    {
        //Transform[] child = transform.GetComponentsInChildren<Transforn>();
        Bind(AreaCode.UI, UIEventCode.Change_Player_Health, UIEventCode.Change_Player_Energy,UIEventCode.Change_Player_Score);
        healthtText = GetOrAddChildGameObject<Text>("HealthValue");

    }
    public T GetOrAddChildGameObject<T>(string name) where T : Component
    {
        //根据名称查找子对象组件
        GameObject child = FindChildGameObject(name);
        if (child)
        {
            if (child.GetComponent<T>() == null)
                child.AddComponent<T>();
            return child.GetComponent<T>();
        }
        return null;
    }

    public GameObject FindChildGameObject(string name)
    {
        //根据名称查找子对象
        Transform[] trans = transform.GetComponentsInChildren<Transform>();

        foreach (Transform item in trans)
        {
            if (item.name == name)
            {
                return item.gameObject;
            }
        }

        Debug.LogWarning($"{transform.name}里面找不到{name}子对象");
        return null;
    }


    public override void Execute(int eventCode, object message)
    {
        //base.Execute(eventCode, message);
        Debug.Log("Change_Player_Health接受消息");
        switch (eventCode)
        {
            case UIEventCode.Change_Player_Health:
                healthtText.text = (int)message+"";
                break;
        }
    }
}
