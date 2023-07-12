using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMStateManager
{


    /// <summary>
    /// 存储所有状态
    /// </summary>
    private FSMState[] states;



    public FSMStateManager(int stateCount)
    {
        Initial(stateCount);
        
    }

    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="stateCount"></param>
    private void Initial(int stateCount)
    {
        states = new FSMState[stateCount];
    }

    /// <summary>
    /// 状态的边界【最后添加的一个状态的下标】
    /// </summary>
    private sbyte countBorder = -1;

    /// <summary>
    /// 当前状态的下标
    /// </summary>
    private sbyte currentIndex = -1;

    /// <summary>
    /// 添加状态
    /// </summary>
    /// <param name="state"></param>
    public void AddState(FSMState state)
    {
        countBorder++;

        if (countBorder > states.Length - 1)
        {
            Debug.Log("添加状态失败，状态已满！");

            return;
        }

        states[countBorder] = state;
    }

    /// <summary>
    /// 运行状态
    /// </summary>
    /// <param name="index"></param>
    public void RunState(int index)
    {
        // 如果当前状态已经运行
        if (currentIndex == index)
        {
            return;
        }

        // 如果已经有状态在运行
        if (currentIndex != -1)
        {
            states[currentIndex].OnExit();
        }

        currentIndex = (sbyte)index;

        // 运行新的状态
        states[currentIndex].OnEnter();
    }

    /// <summary>
    /// 当前状态更新
    /// </summary>
    public void CurrentStateUpdate()
    {
        // 如果当前没有状态
        if (currentIndex == -1)
        {
            return;
        }

        states[currentIndex].OnStay();
    }

    public void CurrentStateFixedUpdate()
    {
        // 如果当前没有状态
        if (currentIndex == -1)
        {
            return;
        }

        states[currentIndex].OnFixedStay();
    }



    /// <summary>
    /// 当前状态
    /// </summary>
    /// <returns></returns>
    public int CurrentState()
    {
        return currentIndex;
    }
}
