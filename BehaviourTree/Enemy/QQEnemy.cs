using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QQEnemy : BTAgent
{

    /// <summary>
    /// 
    /// Ñ²Âß --- ÒÆ¶¯
    /// 
    /// 
    /// 
    /// </summary>
    /// 

    public bool isChangeFwd;

    private QQAttribute qqAttribute;

    new void Start()
    {
        base.Start();
        Bind(AreaCode.Character, CharacterEventCode.Play_Dead, CharacterEventCode.Change_Player_health,
            CharacterEventCode.Change_Player_Energy, CharacterEventCode.To_Read_Character_Msg,
            CharacterEventCode.People_AttackPlayer, CharacterEventCode.To_Save_Character_Msg);
        isChangeFwd = false;
        Leaf isEnd = new Leaf("GO To Van", toGetEndMsg);

        Leaf isHung = new Leaf("ÅÐ¶ÏÊÇ·ñµ½±ßÔµ", isEdge);
        tree.AddChild(isEnd);
    }

    public Node.Status toGetEndMsg() {
        return Node.Status.SUCCES;
    }

    public Node.Status isEdge() {

        return Node.Status.SUCCES;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isChangeFwd = true;
    }
}
