using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeliFSMState 
{   

    /// <summary>
    /// keli 状态类的集合类
    /// </summary>
    
    public KeliRunRight runR;
    public KeliRunLeft runL;
    public KeliDown down;
    public KeliJumpUP jump;

    private MonoBehaviour mono;
    private FSMStateManager fsmStateManager;

    public KeliFSMState(MonoBehaviour monoBehaviour, KeliAttribute keliAttribute) {
        mono = monoBehaviour;
        runR = new KeliRunRight(mono, keliAttribute);
        runL = new KeliRunLeft(mono,  keliAttribute);
        down = new KeliDown(mono,keliAttribute);
        jump = new KeliJumpUP(mono,  keliAttribute);
    }
}

public class KeliRunRight : FSMState
{
    public KeliAttribute keliAttr;
    private MonoBehaviour monoBehaviour;
    private Animator animator;
    private Rigidbody2D rbody;

    private Vector2 dir;
    public KeliRunRight(MonoBehaviour ani,  KeliAttribute keliAttribute)
    {
        keliAttr = keliAttribute;
        
        monoBehaviour = ani;
        animator = ani.GetComponent<Animator>();
        rbody = ani.GetComponent<Rigidbody2D>();
        dir = new Vector2();

    }

    public override void OnEnter()
    {

        if (keliAttr.PlayerControlHorziontal>= 0) {
            animator.SetBool("isRight", true);
        }
    }

    public override void OnStay()
    {
    }
    public override void OnFixedStay()
    {
        dir.x = keliAttr.PlayerControlHorziontal * keliAttr.speed;
        dir.y = rbody.velocity.y;
        rbody.velocity = dir;
    }


    public override void OnExit()
    {

    }
}

public class KeliRunLeft : FSMState
{
    public KeliAttribute keliAttr;
    private MonoBehaviour monoBehaviour;
    private Animator animator;
    private Rigidbody2D rbody;

    private Vector2 dir;


    public KeliRunLeft(MonoBehaviour ani, KeliAttribute keliAttribute)
    {
        keliAttr = keliAttribute;
        
        monoBehaviour = ani;
        animator = ani.GetComponent<Animator>();
        rbody = ani.GetComponent<Rigidbody2D>();
        dir = new Vector2();

    }

    public override void OnEnter()
    {
        if (keliAttr.PlayerControlHorziontal <= 0)
        {
            animator.SetBool("isRight", false);
        }
    }

    public override void OnStay()
    {
    }

    public override void OnFixedStay()
    {
        dir.x = keliAttr.PlayerControlHorziontal * keliAttr.speed;
        dir.y = rbody.velocity.y;
        rbody.velocity = dir;
    }

    public override void OnExit()
    {
    }
}
public class KeliJumpUP : FSMState
{
    public KeliAttribute keliAttr;
    private Animator animator;
    private Rigidbody2D rbody;

    private Vector2 moveDir = new Vector2();

    public KeliJumpUP(MonoBehaviour ani,  KeliAttribute keliAttribute)
    {
        keliAttr = keliAttribute;
        
        animator = ani.GetComponent<Animator>();
        rbody = ani.GetComponent<Rigidbody2D>();
    }

    public override void OnEnter()
    {
     //   Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
        animator.SetBool("isJump", true);
        rbody.velocity  = new Vector2(rbody.velocity.x, keliAttr.JumpSpeedInit);
    }

    public override void OnStay()
    {
    }

    public override void OnFixedStay()
    {
        moveDir.x = keliAttr.Fwd * keliAttr.speed;
        moveDir.y = rbody.velocity.y;
        rbody.velocity = moveDir;
    }

    public override void OnExit()
    {
        animator.SetBool("isJump", false);
    }
}

public class KeliDown : FSMState
{
    public KeliAttribute keliAttr;
    private Animator animator;
    private Rigidbody2D rbody;
    private FSMStateManager fsmStateManager;

    private Vector2 moveDir = new Vector2();

    private float horiztonal = 2f;//下落水平方向阻力
    private float downMaxV;//最大下落速度

    public KeliDown(MonoBehaviour ani,  KeliAttribute keliAttribute)
    {
        keliAttr = keliAttribute;
      
        animator = ani.GetComponent<Animator>();
        rbody = ani.GetComponent<Rigidbody2D>();
    }

    public override void OnEnter()
    {
        animator.SetTrigger("triggerDown");
        animator.SetBool("isDown",true);
    }

    public override void OnStay()
    {
    }

    public override void OnFixedStay()
    {
        moveDir.x = keliAttr.Fwd * keliAttr.speed;
        moveDir.y = rbody.velocity.y;
        rbody.velocity = moveDir;
    }

    public override void OnExit()
    {
        animator.SetBool("isDown", false);
    }
}

