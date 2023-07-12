using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTestClass : MonoBehaviour
{
    public static void Main()
    {
        EventTest e = new EventTest();
        SubscribEvent v = new SubscribEvent();//ÉùÃû¶©ÔÄÀà 
        e.ChangeNum += new EventTest.NumMainpulationHandler(v.printf);
        e.ChangeNum += new EventTest.NumMainpulationHandler(v.printd);
        e.SetValue(7);
        e.SetValue(11);
        e.SetValue(11);

    }

    void Start()
    {
        Debug.Log("Main Test Of EventClass");
        Main();
    }
}
