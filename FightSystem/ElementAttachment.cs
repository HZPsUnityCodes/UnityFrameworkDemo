using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementAttachment
{
    // Ԫ�ظ�����

    public List<ElementTimeCount> elementsAttachList;

    private int MaxAttachElement = 2;
    private int currentAttachElement = 0;

    public ElementAttachment() {
        elementsAttachList = new List<ElementTimeCount>();
    }

    /// <summary>
    /// ���Ԫ�ظ��ż����� ֻ����֡������ʱ��������
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
    /// ֻ����֡������ʱ�� ���м�����ɾ�� ���Ҹ�UI������Ϣ
    /// </summary>
    /// <param name="index"></param>
    public void DeleteElementTimeCount(int index) {
        ///
        /// ����ǰ��Ҫ�ж�
        ////
        if (currentAttachElement > index) {

            elementsAttachList.RemoveAt(index);
            currentAttachElement--;
        }
    }

    /// <summary>
    /// SendMsgToReaction ͨ����Ϣϵͳ�� reaction system ������Ϣ
    /// </summary>
    public void SendMsgToReaction() { 
    
    }


    /// <summary>
    /// Ԫ�ظ�����ֻ���� ����Ԫ���Լ�Ԫ�����͵���Ϣ,ʹ��Э��ʵ��
    /// </summary>
    public void GetMsgFromReaction() {
    }
    /// <summary>
    /// ��monoBehaviour��FixedUpDate ʹ��
    /// ������Ϣ
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
