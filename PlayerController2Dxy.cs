using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerController2Dxy : MonoBehaviour
{

    public float speed = 3f;
    public float currentPercent = 0f;
    public float maxAccTime = 3f;
    public float minV = 4f;
    public float maxV = 20f;
    public GameObject BombLoc;

    Rigidbody2D rbody;

    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private int maxHealth = 5;
    
    private int currentHealth = 3;
    private int currentScore = 0;

    private Vector2 currentPosition;

    private float JumpTime = 5f;
    private float JumpTimeMax = 5f;
    private bool JumpPressed = false;
    private bool BombPressed = false;


    private float JumpSpeedInit = 9f;
    private float JumpSpeed = 0;
    private float G;
    private int JumpCount = 1;

    private bool HangState = false;

    private float BombMaxAccTime;
    private float currentBombAccPercent;
    private float minBombV;
    private float maxBombV;
    private bool bombAccing;
    private float initBombV;

    private string BombTestPath;
    private float bombInitHorziontal;
    private Animator ani;

    public int MyMaxHeath { get { return maxHealth; } }
    public int MyRurrentHealth { get { return maxHealth; }}

    private void PlayerBombInit(float currentPercent, float maxAccTime,float minV,float maxV) {

        BombMaxAccTime = maxAccTime;
        currentBombAccPercent = currentPercent;
        minBombV = minV;
        maxBombV = maxV;
    }

    // Start is called before the first frame update
    void Start()
    {

        bombInitHorziontal = 1f;
        BombTestPath = "Prefabs/Bombs/BombTest";
        rbody = GetComponent<Rigidbody2D>();
        PlayerBombInit(currentPercent, maxAccTime, minV, maxV);
        G = 5f;
        ani = this.GetComponent<Animator>();
    }



    void Update()
    {
        float horziontal = Input.GetAxisRaw("Horizontal");
        if (horziontal > 0) {
            bombInitHorziontal = 1f;
            ani.SetBool("isRight",true);
        }
        if (horziontal < 0) {
            bombInitHorziontal = -1f;
            ani.SetBool("isRight", false);
        }

        if (!HangState) { 
               
        } else {

            JumpSpeed -= G * Time.fixedDeltaTime;
        }
        if (!JumpPressed) {

            if (Input.GetKeyDown(KeyCode.W) && !HangState)
            {
                JumpPressed = true;
                JumpSpeed = JumpSpeedInit;
            }
        }

        if (Input.GetKeyDown(KeyCode.J)) {
            BombPressed = true;
        }
        if (Input.GetKeyUp(KeyCode.J)) {
            Debug.Log("fa she");
            BombPressed = false;
        }

        Vector2 position = rbody.position;

        
        position.y += JumpSpeed * Time.fixedDeltaTime;
        position.x += horziontal * speed * Time.fixedDeltaTime;

        
        rbody.MovePosition(position);
        currentPosition = position;
    }

    private void FixedUpdate()
    {
        if (BombPressed) {
            bombAccing = true;
            currentBombAccPercent =  ThrowAccPercent(currentBombAccPercent, Time.fixedDeltaTime, BombMaxAccTime);
        }

        if ((!BombPressed) && bombAccing) {
            initBombV = GetThrowInitV(currentBombAccPercent, minBombV, maxBombV);
            GameObject BombPrefab = (GameObject)Resources.Load(BombTestPath);
            BombPrefab.GetComponent<BombDynamics>().Init(30,initBombV, bombInitHorziontal);
            GameObject testBomb = Instantiate(BombPrefab,BombLoc.transform.position,Quaternion.identity);
            bombAccing = false;
            currentBombAccPercent = 0f;
        }
    }


    public float GetCurrentJumpSpeed(float MG,float CurrentSpeed,float detime) 
    {
        //获取跳跃当前的y分量的瞬时速度
        CurrentSpeed = CurrentSpeed - MG * detime;

        return CurrentSpeed;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag.Equals("ground") && (collision.contacts[0].normal.y == 1)) {
            HangState = false;
            JumpSpeed = 0;
            JumpPressed = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //Debug.Log(collision.collider.name);
        if(collision.collider.tag.Equals("ground") && (collision.contacts[0].normal.y == 1)) {
            HangState = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.collider.tag.Equals("ground"))
        {
            HangState = true;
        }
    }

    private float ThrowAccPercent(float currentPercent,float accTime,float maxAccTime) {
        //返回当前蓄力百分比
        float accPercent = Mathf.Clamp01(accTime / maxAccTime);
        currentPercent = currentPercent + accPercent;
        return currentPercent;
    }

    private Vector2 GetThrowVecx(float accPer) {
        //用来获得发射向量。
        //角度调整一开始快，后来慢。
        float sinTheta = accPer;
        Vector2 Theta = new Vector2(Mathf.Sqrt(1 - sinTheta * sinTheta), sinTheta);
        return Theta;
    }

    private float GetThrowInitV(float accPer,float minInitV,float maxInitV) {
        //用来获得发射初始速 minInitV  和 maxInitV 之间
        //Debug.Log($"{minInitV} - {maxInitV}");
        float throwInitV = (maxInitV - minInitV) * accPer + minInitV;
        return throwInitV;
    }
}
