using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateManager
{


    /// <summary>
    /// �洢����״̬
    /// </summary>
    private FSMState[] states;



    public FSMStateManager(int stateCount)
    {
        Initial(stateCount);
        
    }

    /// <summary>
    /// ��ʼ��
    /// </summary>
    /// <param name="stateCount"></param>
    private void Initial(int stateCount)
    {
        states = new FSMState[stateCount];
    }

    /// <summary>
    /// ״̬�ı߽硾�����ӵ�һ��״̬���±꡿
    /// </summary>
    private sbyte countBorder = -1;

    /// <summary>
    /// ��ǰ״̬���±�
    /// </summary>
    private sbyte currentIndex = -1;

    /// <summary>
    /// ���״̬
    /// </summary>
    /// <param name="state"></param>
    public void AddState(FSMState state)
    {
        countBorder++;

        if (countBorder > states.Length - 1)
        {
            Debug.Log("���״̬ʧ�ܣ�״̬������");

            return;
        }

        states[countBorder] = state;
    }

    /// <summary>
    /// ����״̬
    /// </summary>
    /// <param name="index"></param>
    public void RunState(int index)
    {
        // �����ǰ״̬�Ѿ�����
        if (currentIndex == index)
        {
            return;
        }

        // ����Ѿ���״̬������
        if (currentIndex != -1)
        {
            states[currentIndex].OnExit();
        }

        currentIndex = (sbyte)index;

        // �����µ�״̬
        states[currentIndex].OnEnter();
    }

    /// <summary>
    /// ��ǰ״̬����
    /// </summary>
    public void CurrentStateUpdate()
    {
        // �����ǰû��״̬
        if (currentIndex == -1)
        {
            return;
        }

        states[currentIndex].OnStay();
    }

    public void CurrentStateFixedUpdate()
    {
        // �����ǰû��״̬
        if (currentIndex == -1)
        {
            return;
        }

        states[currentIndex].OnFixedStay();
    }



    /// <summary>
    /// ��ǰ״̬
    /// </summary>
    /// <returns></returns>
    public int CurrentState()
    {
        return currentIndex;
    }
}
