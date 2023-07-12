using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeliController : MonoBase
{
    public KeliAttribute KeliAttr;
    public string BombTestPath;
    public FSMStateManager fsm;
    public KeliFSMState keliFSMState;
    public Rigidbody2D rbody;


    public float beforeFrameFwd;
    public bool allCompenentFlip; 
   
    
    // Start is called before the first frame update
    void Start()
    {
        
        rbody = this.GetComponent<Rigidbody2D>();
        KeliAttr = new KeliAttribute(this.transform.position.x, this.transform.position.y, 5f, true, this.GetComponent<Rigidbody2D>());

        KeliAttr.BombInitHorziontal = 1f;
        beforeFrameFwd = 1f;
        KeliAttr.BombTestPath = "Prefabs/Bombs/BombTest";

        allCompenentFlip = false;
        fsm = new FSMStateManager(4);

        KeliAttr.HangState = true;
        keliFSMState = new KeliFSMState(this, KeliAttr);
        fsm.AddState(keliFSMState.runL);
        fsm.AddState(keliFSMState.runR);
        fsm.AddState(keliFSMState.jump);
        fsm.AddState(keliFSMState.down);
        fsm.RunState(1);

        KeliAttr.IsKeliActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        KeliAttr.PlayerControlHorziontal = Input.GetAxisRaw("Horizontal");

       

        if (!KeliAttr.JumpPressed)
        {
            if (KeliAttr.PlayerControlHorziontal > 0)
            {
                KeliAttr.Fwd = 1f;


                fsm.RunState(1);
            }
            if (KeliAttr.PlayerControlHorziontal == 0)
            {
                KeliAttr.Fwd = 0f;
                //fsm.RunState(1);
            }

            if (KeliAttr.PlayerControlHorziontal < 0)
            {
                KeliAttr.Fwd = -1f;

                fsm.RunState(0);
            }

            if (Input.GetKeyDown(KeyCode.W) && !KeliAttr.HangState)
            {
                KeliAttr.JumpPressed = true;
                KeliAttr.JumpSpeed = KeliAttr.JumpSpeedInit;
                if (KeliAttr.JumpSpeed > 0) 
                    fsm.RunState(2);
            }
        }

        if (Mathf.Abs(beforeFrameFwd - KeliAttr.Fwd) > 1) {
            Debug.Log("okk allCompenentFlip");
            allCompenentFlip = true;
            
        }
        else
            allCompenentFlip = false;
        if (KeliAttr.Fwd != 0) {
            beforeFrameFwd = KeliAttr.Fwd;
        }
        childrenFlip();


        fsm.CurrentStateUpdate();

    }
    private void FixedUpdate()
    {
        if (!KeliAttr.HangState)
        {
        }
        else
        {

            rbody.velocity = new Vector2(rbody.velocity.x, rbody.velocity.y - KeliAttr.G * Time.fixedDeltaTime);
        }

        if (rbody.velocity.y < 0 && KeliAttr.HangState)
        {
            fsm.RunState(3);
        }
        fsm.CurrentStateFixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("ground") && (collision.contacts[0].normal.y == 1))
        {
            Debug.Log($"ÂäµØ");
            KeliAttr.HangState = false;
            rbody.velocity = new Vector2(0,0);
            KeliAttr.JumpPressed = false;

            fsm.RunState(1);

        }

        if (collision.collider.tag.Equals("ground") && (collision.contacts[0].normal.y == -1)) {
            if (KeliAttr.JumpSpeed > 0)
            {
                KeliAttr.JumpSpeed = 0;
            }
        }

        if (collision.collider.tag.Equals("ground") && (collision.contacts[0].normal.x == -1))
        {
            if (KeliAttr.PlayerControlHorziontal > 0)
            {
                KeliAttr.ColliderBoxhorizon1 = 0;

            }
        }
        if (collision.collider.tag.Equals("ground") && (collision.contacts[0].normal.x == 1))
        {
            if (KeliAttr.PlayerControlHorziontal < 0)
            {
                KeliAttr.ColliderBoxhorizon1 = 0;
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.collider.tag.Equals("ground") && (collision.contacts[0].normal.y == 1) )
        {
            
            KeliAttr.HangState = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("ground"))
        {
            KeliAttr.HangState = true;
        }
    }

    public void childrenFlip() {
        if (allCompenentFlip ) {

            Transform at = this.transform.Find("BombLocation");
            Vector3 p = at.localPosition;
            
            at.localPosition = flip(p);


            Transform bt = this.transform.Find("leftHungCheck");
            Vector3 p2 = bt.localPosition;
            bt.localPosition = flip(p2);
            //this.transform.Find("leftHungCheck").transform;

        }
    }

    public Vector3 flip(Vector3 position) {
        position.x = -position.x;
        return position;
    }
}
