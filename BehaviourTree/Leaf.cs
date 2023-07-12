using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaf : Node
{
    public delegate Status Tick();
    /// <summary>
    /// Î¯ÍÐ
    /// </summary>
    public Tick ProcessMethod;

    public delegate Status TickIndex();
    public TickIndex ProcessMethodIndex;
    public int index;



    public Leaf() { }

    public Leaf(string n,Tick pm)
    {
        name = n;
        ProcessMethod = pm;

    }
    public Leaf(string n, int index,TickIndex pm)
    {
        name = n;
        ProcessMethodIndex = pm;

    }

    public Leaf(string n, Tick pm,int important)
    {
        name = n;
        ProcessMethod = pm;
        sortOrder = important;
    }

    public override Status Process()
    {
        if (ProcessMethod != null)
            return ProcessMethod();
        else if (ProcessMethod != null)
            return ProcessMethodIndex();
        return Status.FAILURE;
    }
}
