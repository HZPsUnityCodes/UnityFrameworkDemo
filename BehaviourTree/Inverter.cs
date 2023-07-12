using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    /// <summary>
    /// Inverter Ϊ��Ϊ���ϵ�һ���ڵ㣬ֻ��һ���ӽڵ㡣
    /// 
    /// ���ӽڵ�Process() ΪFAILURE��ʱ��,Inverter �ŷ���SUCESS����ζ����Inverter �ֵܽڵ㣩
    /// </summary>
    /// <param name="n"></param>
    public Inverter(string n) 
    {
        name = n;
    }

    public override Status Process()
    {
        Status childstatus = children[0].Process();

        if (childstatus == Status.RUNING) return Status.RUNING;

        if (childstatus == Status.FAILURE)
            return Status.SUCCES;
        else
            return Status.FAILURE;
    }
}
