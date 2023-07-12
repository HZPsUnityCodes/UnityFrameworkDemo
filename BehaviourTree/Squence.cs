using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squence : Node
{
    /// <summary>
    /// Squence 序列节点
    /// 只有子节点运行成功才运行下个节点
    /// 只有所有儿子节点运行成功才 会   返回成功
    /// </summary>
    public Squence() { }

    public Squence(string n)
    {
        name = n;
    }

    public override Status Process()
    {
        Status childStatus = children[currentChild].Process();
        if (childStatus == Status.RUNING) {
            return Status.RUNING;
        }

        if (childStatus == Status.FAILURE) {
            return childStatus;
        }
        if (childStatus == Status.SUCCES)
        {
            currentChild++;
        }

        if (currentChild >= children.Count) {
            currentChild = 0;
            return Status.SUCCES;
        }
        return Status.RUNING;
    }
}
