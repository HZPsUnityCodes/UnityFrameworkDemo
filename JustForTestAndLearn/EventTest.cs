using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventTest 
{
    private int n = 0;

    public delegate void NumMainpulationHandler(int TestValue);

    public event NumMainpulationHandler ChangeNum;

    public event EventHandler Onattack;
    protected virtual void OnNumChanged()
    {
        if (ChangeNum != null)
        {
            ChangeNum(n);
        }
        else {
            Debug.Log("event not fire");
        }
    }

    public EventTest()
    {
        SetValue(n);
    }
     
    public void SetValue(int in_n)
    {
        if ( n != in_n)
        {
            n = in_n;
            OnNumChanged();
        }
    }
}
