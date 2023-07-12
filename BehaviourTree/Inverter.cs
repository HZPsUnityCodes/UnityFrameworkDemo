using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    /// <summary>
    /// Inverter 为行为树上的一个节点，只有一个子节点。
    /// 
    /// 当子节点Process() 为FAILURE的时候,Inverter 才返回SUCESS（意味运行Inverter 兄弟节点）
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
