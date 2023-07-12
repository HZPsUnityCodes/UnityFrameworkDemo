using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState
{
    /// <summary>
    /// ����״̬
    /// </summary>
    /// 
    public virtual void OnEnter()
    { 
    
    }

    /// <summary>
    /// FixedUpdate �и���
    /// </summary>
    public virtual void OnFixedEnter()
    {

    }

    /// <summary>
    /// ״̬��
    /// </summary>
    public virtual void OnStay()
    { 
    
    }

    public virtual void OnFixedStay()
    {

    }

    /// <summary>
    /// �˳�״̬
    /// </summary>
    public virtual void OnExit()
    { 
    
    }

    public virtual void OnFixedExit()
    {

    }
}
