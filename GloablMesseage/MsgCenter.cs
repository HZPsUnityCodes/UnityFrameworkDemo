using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MsgCenter : MonoBehaviour
{
    public static MsgCenter Instance = null;
    private Dictionary<AreaCode, ManagerBase> Managers = new Dictionary<AreaCode, ManagerBase>();

    private void Awake()
    {
        Instance = this;
        AddManager<CharacterMsgManager>(AreaCode.Character);
        AddManager<GameMsgManager>(AreaCode.Game);
        AddManager<UIMsgManager>(AreaCode.UI);
        AddManager<AudioMsgManager>(AreaCode.Audio);
        AddManager<RecordMsgManager>(AreaCode.Record);
    }
    public void Dispatch(AreaCode areaCode,int eventCode,object message)
    { 
        if (Managers.ContainsKey(areaCode))
        {
            Managers[areaCode].Execute(eventCode, message); 
        }
    }

    public T AddManager<T>(AreaCode areaCode) where T : ManagerBase
    {
        ManagerBase managerBase = gameObject.AddComponent<T>();
        Managers.Add(areaCode,managerBase);

        return managerBase.GetComponent<T>();
    }

    public ManagerBase GetManager(AreaCode areaCode)
    {
        if (Managers.ContainsKey(areaCode))
        {
            return Managers[areaCode];
        }
        else
        {
            Debug.LogError($"you forget add{areaCode.ToString()}MsgManager");
            return null;
        }
    }
}

public class CharacterMsgManager:ManagerBase
{
    private void Awake()
    {
        areaCode = AreaCode.Character;
    }
}


public class GameMsgManager : ManagerBase
{
    private void Awake()
    {
        areaCode = AreaCode.Game;
    }
}


public class UIMsgManager : ManagerBase
{
    private void Awake()
    {
        areaCode = AreaCode.UI;
    }
}

public class AudioMsgManager : ManagerBase
{
    private void Awake()
    {
        areaCode = AreaCode.Audio;
    }
}

public class RecordMsgManager : ManagerBase
{
    private void Awake()
    {
        areaCode = AreaCode.Record;
    }
}