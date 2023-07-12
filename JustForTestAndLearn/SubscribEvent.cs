using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubscribEvent 
{

    public void printf(int delegate_n) {
        Debug.Log("printf make Event fire" + delegate_n);
    }

    public void printd(int delegate_n)
    {
        Debug.Log("printd  make Event fire" + delegate_n);
    }
}
