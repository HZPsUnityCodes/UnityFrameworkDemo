using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node
{
    public Selector(string n) {
        name = n;
    }

    public override Status Process()
    {
        
        Status childStatus = children[currentChild].Process();

        if (childStatus == Status.RUNING)
        {
            return Status.RUNING;
        }
        if (childStatus == Status.SUCCES)
        {
            currentChild = 0;
            return Status.SUCCES;
        }

        if (childStatus == Status.FAILURE)
            currentChild++;

        if (currentChild >= children.Count)
        {
            currentChild = 0;
            return Status.FAILURE;
        }
        return Status.RUNING;
    }
}
