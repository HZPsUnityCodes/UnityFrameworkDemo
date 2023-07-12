using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敌人控制相关

public class EnemyContoller2D : MonoBase
{

    

    public float changeDireactionTime = 2f;

    private float changeTimer;

    public bool isVertical;
    public Vector2 moveDireaction;

    public float speed = 3;

    public Animator ani;

    private bool interacTimeTrigger;

    private Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        moveDireaction = isVertical ? Vector2.up : Vector2.right;
        changeTimer = changeDireactionTime;
        ani = GetComponent<Animator>();
        ani.SetBool("isUP",true);
        interacTimeTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (interacTimeTrigger == true) {
            changeTimer -= Time.deltaTime;
        }
        
        if (changeTimer < 0) {
            moveDireaction *= -1;
            if (moveDireaction.Equals(Vector2.up))
            {
                ani.SetBool("isUP", true);
            }
            else {
                ani.SetBool("isUP", false);
            }
 
           
            changeTimer = changeDireactionTime;
        }
        Vector2 position = rbody.position;
        position.x += moveDireaction.x * speed * Time.deltaTime;
        position.y += moveDireaction.y * speed * Time.deltaTime;
        rbody.MovePosition(position);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController2D pc = collision.GetComponent<PlayerController2D>();
        if (pc != null) {
            interacTimeTrigger = false;
            ani.SetTrigger("isFixed");

            speed = 0;
            pc.ChangeHealth(-1);
            Debug.Log("和玩家 发生了碰撞");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController2D pc = collision.GetComponent<PlayerController2D>();
        if (pc != null)
        {
            ani.SetTrigger("isFixed");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController2D pc = collision.GetComponent<PlayerController2D>();
        if (pc != null)
        {
            interacTimeTrigger = true; 
            speed = 3;
            Debug.Log("和玩家 结束碰撞");
        }
    }

}
