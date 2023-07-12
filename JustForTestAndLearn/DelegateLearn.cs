using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateLearn : MonoBehaviour 
{
    delegate int IntAddMethod(int a , int b);
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Delegate Learn ");
        IntAddMethod int_add = null;
        int Account_Money = 100;
        int Input_money = 50;
        int_add = MyAdd;
        Debug.Log("½á¹û"+int_add(Account_Money,Input_money));
        IntAddMethod[] AddMethodDelegates = { };
        List<IntAddMethod> AddMethodDelegateList = new List<IntAddMethod>();
    }

    public static int MyAdd(int a,int b) {  
        return a + b;
    }
    public static int MyAdd_a(int a, int b)
    {
        return a + b;
    }
    public static int MyAdd_b(int a, int b)
    {
        return a + b;
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log("DelegateLearn");
    }
}
