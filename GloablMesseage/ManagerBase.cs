using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerBase : MonoBase
{

    protected AreaCode areaCode;

    /// <summary>
    /// dict ���¼��� MonoBase�������һ����  ��Ϣ�б�
    /// </summary>
    private Dictionary<int, List<MonoBase>> dict = new Dictionary<int,List<MonoBase>>();
    

    /// <summary>
    /// ������Ϣ ����eventCode ������Ϣ
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="message"></param>
    public override void Execute(int eventCode, object message)
    {
     

        if (!dict.ContainsKey(eventCode))
        {
            Debug.LogWarning($"û��ע��{eventCode}");
            return;
        }

        List<MonoBase> list = dict[eventCode];
        for (int i = 0; i < list.Count; i++)
        {
            list[i].Execute(eventCode,message);
        }
    }


    /// <summary>
    /// ע����Ϣ
    /// </summary>
    /// <param name="eventCode"></param>
    /// <param name="mono"></param>
    public void Add(int eventCode, MonoBase mono)
    {
        List<MonoBase> list = null;

        if (!dict.ContainsKey(eventCode))
        {
            list = new List<MonoBase>();
            list.Add(mono);
            dict.Add(eventCode, list);
            return;
        }

        //C# ����ֵ���ָ����ʽ��
        list = dict[eventCode];
        list.Add(mono);
    }

    public void Add(int[] eventCodes,MonoBase mono)
    {
        for (int i = 0; i < eventCodes.Length; i++)
        {
            Add(eventCodes[i],mono);
        }
    }


    public void Remove(int eventCode , MonoBase mono) { 
        if (!dict.ContainsKey(eventCode))
            {
            Debug.LogWarning($"û������¼�{eventCode}ע��");
        }
        List<MonoBase> list = dict[eventCode];

        if (list.Count == 1)
            dict.Remove(eventCode);
        else
            list.Remove(mono);
    }

    public void Remove(int[] eventCodes, MonoBase mono)
    {
        for (int i = 0; i<eventCodes.Length;i++)
        {
            Remove(eventCodes[i], mono);
        }
    }


    public virtual void OnDestory()
    {
        if (list != null)
            UnBind(areaCode);
    }
}
