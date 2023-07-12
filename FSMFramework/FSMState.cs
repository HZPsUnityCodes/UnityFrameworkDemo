using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState
{
    /// <summary>
    /// 进入状态
    /// </summary>
    /// 
    public virtual void OnEnter()
    { 
    
    }

    /// <summary>
    /// FixedUpdate 中更新
    /// </summary>
    public virtual void OnFixedEnter()
    {

    }

    /// <summary>
    /// 状态中
    /// </summary>
    public virtual void OnStay()
    { 
    
    }

    public virtual void OnFixedStay()
    {

    }

    /// <summary>
    /// 退出状态
    /// </summary>
    public virtual void OnExit()
    { 
    
    }

    public virtual void OnFixedExit()
    {

    }
}
