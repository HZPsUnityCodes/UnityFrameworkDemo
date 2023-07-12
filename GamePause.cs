using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausingBehaviour : MonoBehaviour
{
    /// <summary>
    /// 是否暂停逻辑处理.
    /// </summary>
    public static bool pause { get; set; }

    static PausingBehaviour()
    {
        pause = false;
    }

    private bool _isPaused;

    protected virtual void OnEnable()
    {
        _isPaused = pause;
    }

    protected virtual void Update()
    {
        if (!pause)
        {
            if ( _isPaused )
            {
                _isPaused =  false ;

                this.OnPauseExit();
            }

            this.OnUpdate();
        }

        else
        {
            if (!_isPaused)
            {
                _isPaused = true;
                this.OnPauseEnter();
            }
        }
    }

    /// <summary>
    /// 可暂停的逻辑更新方法.
    /// </summary>
    protected virtual void OnUpdate()
    {
    }

    protected virtual void LateUpdate()
    {
        if (!pause)
        {
            this.OnLateUpdate();
        }
    }

    /// <summary>
    /// 可暂停的逻辑更新方法.
    /// </summary>
    protected virtual void OnLateUpdate()
    {
    }

    /// <summary>
    /// 暂停开始时会调用该方法.
    /// </summary>
    protected virtual void OnPauseEnter()
    {
    }

    /// <summary>
    /// 暂停结束时会调用该方法.
    /// </summary>
    protected virtual void OnPauseExit()
    {
    }
}
