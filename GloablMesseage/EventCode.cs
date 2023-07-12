using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventCode
{   
    /// <summary>
    /// 玩家血量变化事件
    /// </summary>
    public const int Change_Player_Health = 0;
    /// <summary>
    /// 玩家能量变化事件
    /// </summary>
    public const int Change_Player_Energy = 11;

    public const int Change_Player_Score = 2;
    /// <summary>
    /// 用于初始化UI面板数值事件
    /// </summary>
    public const int Init_msg = 3;
}

public class GameEventCode
{
    public const int WoodBlockOn = 0;
    public const int SwitchColumOn = 1;
    public const int SwitchColumOff = 2;
    public const int DownBlockDown = 3;

}

public class CharacterEventCode
{
    public const int Change_Player_health = 0;
    public const int Change_Player_Energy = 1;
    public const int Play_Dead = 2;
    public const int People_HurtByWeapon = 3;
    public const int People_AttackPlayer = 4;
    public const int To_Save_Character_Msg = 5;
    public const int To_Read_Character_Msg = 6;
}

public class AudioEventCode
{

}

public class RecordEventCode
{
    public const int Game_Record_save = 0;

    public const int Game_Record_read = 1;

    public const int GamePause = 2;
    public const int GameResume = 3;
}

public class FightCalculateEventCode {

    public const int DamagerFigureEnd = 0;
    public const int DamagerFigureStart = 1;

}

public class ElementReactionEventCode {
    public const int Freeze = 0;
    public const int Intensfy = 1;
    public const int Burning = 2;
    public const int Evaporation = 3;
    public const int Thaw = 4;
}