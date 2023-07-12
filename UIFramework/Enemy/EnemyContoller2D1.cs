using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人控制相关

public class EnemyContoller2D1 : MonoBase
{


    public FSMStateManager fsm;

    public EnemyFSMState enemyFSMState;
    public float changeDireactionTime = 2f;

    private float changeTimer;

    public bool isVertical=true;
    public Vector2 moveDireaction;

    public float speed = 3;

    public Animator ani;

    private bool interacTimeTrigger;

    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {

        fsm = new FSMStateManager(2);
        enemyFSMState = new EnemyFSMState(this, fsm);
        fsm.AddState(enemyFSMState.idle);
        fsm.AddState(enemyFSMState.walk);
        fsm.RunState(0);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.CurrentStateUpdate();
    }
}
