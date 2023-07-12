using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MonoType
{ 
    Player,
    Enemy,
    Interaction,
    Prop,
    HiddenWeapon,
    Platform,
    Weapon,
    Water,
    UI,
    Audio,
    Switch,
    Block,
    Charactor
}
public class MonoBase : MonoBehaviour
{
    public bool CanInteractiveWithPlayer;
    public bool CanInteractiveWithWeapon;
    public ElementAttachment elementAttachment;
    public ElementTimeCount oneAttack;

    public virtual void TriggerEnterEventWithPlayer(PlayerController2D player) { }

    public virtual void TriggerStayEventWithPlayer(PlayerController2D player) { }

    public virtual void ColliderWithPlayer(PlayerController2D player) { }




    public virtual void Execute(int eventCode , object message)
    { 
    
    }

    //消息集合 自身关心的消息集合
    internal List<int> list = new List<int>();

    /// <summary>
    /// 消息绑定
    /// </summary>
    /// <param name="areaCode"></param>
    /// <param name="eventCodes"></param>
    protected void Bind(AreaCode areaCode , params int[] eventCodes)
    {
        list.AddRange(eventCodes);
        ManagerBase manager = MsgCenter.Instance.GetManager(areaCode);
        manager.Add(list.ToArray(),this);
    }

    /// <summary>
    /// 接触绑定的消息
    /// </summary>
    /// <param name="areaCode"></param>
    protected void UnBind(AreaCode areaCode)
    {
        ManagerBase manager = MsgCenter.Instance.GetManager(areaCode);
        manager.Remove(list.ToArray(), this);
        list.Clear();

    }

    /// <summary>
    /// 发消息
    /// </summary>
    /// <param name="areaCode"></param>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    public void Dispatch(AreaCode areaCode, int eventCode, object message)
    {
        MsgCenter.Instance.Dispatch(areaCode,eventCode,message);
    }
}
