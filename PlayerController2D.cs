using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerController2D : MonoBase 
{

    public float speed = 5f;

    Rigidbody2D rbody;

    private int maxHealth = 5;
    
    private int currentHealth=3;

    private int currentScore = 0;

    private Vector2 currentPosition;


    public int MyMaxHeath { get { return maxHealth; } }
    public int MyRurrentHealth { get { return maxHealth; } }

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        Bind(AreaCode.Character, CharacterEventCode.Play_Dead, CharacterEventCode.Change_Player_health,
            CharacterEventCode.Change_Player_Energy,CharacterEventCode.To_Read_Character_Msg,
            CharacterEventCode.People_AttackPlayer, CharacterEventCode.To_Save_Character_Msg);
        InitState();
    }


    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxisRaw("Vertical");
        float horziontal = Input.GetAxisRaw("Horizontal");

        Vector2 position = rbody.position;
        //ani.
        position.y += vertical * speed * Time.fixedDeltaTime;
        position.x += horziontal * speed * Time.fixedDeltaTime;
        

        rbody.MovePosition(position);
        currentPosition = position;

    }

    public override void Execute(int eventCode, object message)
    {
        switch (eventCode)
        {
            case CharacterEventCode.Play_Dead:
                Debug.Log("dead");
                break;

            case CharacterEventCode.Change_Player_health:
                ChangeHealth((int)message);
                Debug.Log("生命值改变");
                break;

            case CharacterEventCode.People_AttackPlayer:
                Debug.Log("收到攻击");
                break;

            case CharacterEventCode.To_Save_Character_Msg:
                //Dispatch(AreaCode.Character, CharacterEventCode.To_Save_Character_Msg, null);
                Debug.Log("收到退出游戏的指令，并且Dispatch 保存消息命令");
                ToSaveState();
                break;

            case CharacterEventCode.To_Read_Character_Msg:
                //Dispatch(AreaCode.Character, CharacterEventCode.To_Save_Character_Msg, null);
                Debug.Log("读取消息");
                SaveScript loadermsg = (SaveScript)message;
                ToReadState(loadermsg);
                InitState();
                break;

        }
    }

    /// <summary>
    /// 向其他组件发送角色的血量更改
    /// </summary>
    public void ChangeHealth(int ChangeCount) {
        currentHealth = Mathf.Clamp(ChangeCount + currentHealth, 0, maxHealth);
        Dispatch(AreaCode.UI, UIEventCode.Change_Player_Health, currentHealth);
        
    }

    /// <summary>
    /// 向其他组件发送角色的初始状态
    /// </summary>
    private void InitState()
    {
        Dispatch(AreaCode.UI, UIEventCode.Change_Player_Health, currentHealth);
        Dispatch(AreaCode.UI, UIEventCode.Change_Player_Energy, currentScore);
    }

    private void ToSaveState()
    {
        SaveScript msg = new SaveScript();
        msg.healthValue = currentHealth;
        msg.ScoreValue = currentScore;
        msg.playerPositionX = currentPosition.x;
        msg.playerPositionY = currentPosition.y;
        Dispatch(AreaCode.Record, RecordEventCode.Game_Record_save, msg);
        Debug.Log("分发保存消息Game_Record_save");
    }

    private void ToReadState(SaveScript msg)
    {

        currentHealth=msg.healthValue ;
        currentScore = msg.ScoreValue ;
        currentPosition.x = msg.playerPositionX;
        currentPosition.y = msg.playerPositionY;
        Dispatch(AreaCode.Record, RecordEventCode.Game_Record_save, msg);
        Debug.Log("分发保存消息Game_Record_save");
    }

    private void OnSkillButtonDown()
    {
        CharacterSkillManager skillManager = GetComponent<CharacterSkillManager>();
        SkillData data = skillManager.PrepareSkill(10001);
        if (data != null)
            skillManager.GenerateSkill(data);
    }
    //多个按钮 绑定一个方法
    //需要通过事件参数类，区分点击的按钮。
}
