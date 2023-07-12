using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAttachment
{
    // 元素附着器

    public List<ElementTimeCount> elementsAttachList;

    private int MaxAttachElement = 2;
    private int currentAttachElement = 0;

    public ElementAttachment() {
        elementsAttachList = new List<ElementTimeCount>();
    }

    /// <summary>
    /// 添加元素附着计数器 只会在帧结束的时候进行添加
    /// </summary>
    /// <param name="e"></param>
    /// <param name="t"></param>
    /// <param name="q"></param>
    public void AddElementTimeCount(Elements e, float t, float q)
    {
        if (elementsAttachList.Count < MaxAttachElement) {
            elementsAttachList.Add(new ElementTimeCount(e, t, q));
            currentAttachElement++;
            //elementsAttachList.RemoveAt();
        }
    }

    /// <summary>
    /// 只会在帧结束的时候 进行计数器删除 并且给UI发送消息
    /// </summary>
    /// <param name="index"></param>
    public void DeleteElementTimeCount(int index) {
        ///
        /// 调用前需要判断
        ////
        if (currentAttachElement > index) {

            elementsAttachList.RemoveAt(index);
            currentAttachElement--;
        }
    }

    /// <summary>
    /// SendMsgToReaction 通过消息系统向 reaction system 发送消息
    /// </summary>
    public void SendMsgToReaction() { 
    
    }


    /// <summary>
    /// 元素附着器只接受 增加元素以及元素类型的消息,使用协程实现
    /// </summary>
    public void GetMsgFromReaction() {
    }
    /// <summary>
    /// 给monoBehaviour的FixedUpDate 使用
    /// 接受消息
    /// 
    /// </summary>
    /// <param name="time"></param>
    public void FixedUpdateAttachment(float time) {
        
        
        if (currentAttachElement == 2) {
            SendMsgToReaction();
        }
        bool[] a = new bool[currentAttachElement];
        //elementsAttachList.Sort((x,y)=> { return y.AttachTime.CompareTo(x.AttachTime); });
        for (int i = 0;i < currentAttachElement;i++) {
            a[i] = elementsAttachList[i].TimeCountdown(time);
        }

        int deletCount = 0;
        for (int i = 0; i < currentAttachElement; i++)
        {
            if (!a[i]) { 
                DeleteElementTimeCount(i);
                deletCount++;
            } 
        }
        currentAttachElement = currentAttachElement - deletCount;

    }
}
