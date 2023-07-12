using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ElementTimeCount
{
    //元素计数器
    private float attachTime;
    private Elements ele;
    private float attachQuantity;

    public void PlaceHolder() {
        attachTime = 0;
        ele = Elements.NULL;
        attachQuantity = 0;
    }
    public ElementTimeCount(Elements e, float t, float q)
    {
        attachTime = t;
        ele = e;
        attachQuantity = q;
    }


    public Elements Ele { get => ele; set => ele = value; }
    public float AttachQuantity { get => attachQuantity; set => attachQuantity = value; }
    public float AttachTime { get => attachTime; set => attachTime = value; }


    /// <summary>
    /// 随着时间自减，剩余时间小于0，返回false
    /// </summary>
    /// <param name="ts"></param>
    public bool TimeCountdown(float ts)
    {

        if (attachTime - ts > 0) {
            attachTime = attachTime - ts;
            return true;
        }
        else
        {
            attachTime = 0;
            attachQuantity = 0;
            ele = Elements.NULL;
            return false;
        }
    }

    public bool QuantityDown(float q) {
        if (attachQuantity - q > 0)
        {
            attachQuantity = attachQuantity - q;
            return true;
        }
        else
        {
            attachTime = 0;
            attachQuantity = 0;
            ele = Elements.NULL;
            return false;
        }

    }

}
