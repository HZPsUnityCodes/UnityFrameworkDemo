using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDynamics : MonoBehaviour
{

    public float InitV;
    public float InitTheta;
    public float horziontal;
    private float Vx;
    private float Vy;
    
    private Rigidbody2D rbody;
    private CircleCollider2D bombCollider;
    private float G;
    private bool isExposin;
    private Vector2 positionBomb;
    private float allTime;
    private Vector2 normlExposion;

    // Start is called before the first frame update
    void Start()
    {
        allTime = 0;
        G = 5f;
        //InitV = 5;
        Debug.Log($"Start is run   initV{ InitTheta } and initV {InitV}");
        //InitTheta = 30;
        if (horziontal >= 0)
        {
            Vx = InitV * Mathf.Cos(InitTheta / 180 * Mathf.PI);
            
        }
        else {

            Vx = -InitV * Mathf.Cos(InitTheta / 180 * Mathf.PI);
            
        }
        Vy = InitV * Mathf.Sin(InitTheta / 180 * Mathf.PI);

        rbody = this.GetComponent<Rigidbody2D>();
        bombCollider = this.GetComponent<CircleCollider2D>();

        positionBomb = this.transform.position;
        
    }

    public void Init(float initTheta, float initV, float hor) {
        Debug.Log($"public void Init  is run   initV{ initTheta } and initV {initV}");
        InitTheta = initTheta;
        InitV = initV;
        horziontal = hor;
    }

    // Update is called once per frame
    void Update()
    {
        allTime = allTime + Time.fixedDeltaTime;
        rbody.MovePosition(positionBomb);

        if (allTime >= 0.5)
        {
            bombCollider.isTrigger = false;
        }
        if (allTime >= 4f || isExposin) {
            Destroy(this.gameObject);
        }
    }

    private void FixedUpdate()
    {
        VyFun(Time.fixedDeltaTime);
        positionBomb.x += Vx * Time.fixedDeltaTime;
        positionBomb.y += Vy * Time.fixedDeltaTime;
    }

    private void VyFun(float time) {
        Vy -= time * G; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider != null && (allTime >= 0.5f )) {
            Debug.Log($"·¢ÉúÁËÅö×²");
            isExposin = true;
            normlExposion = collision.contacts[0].normal;
        }
    } 
}
