using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepSquence : Node
{
    BehaviourTree dependancy;
    public DepSquence() { }

    public DepSquence(string n, BehaviourTree d)
    {
        name = n;
        dependancy = d;
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
