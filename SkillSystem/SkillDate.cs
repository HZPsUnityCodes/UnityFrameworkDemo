using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum SkillAttackType
{ 
    
}

public enum SelectorType
{

}

[Serializable]
public class SkillData
{
    
    public int skillID;
    /// <summary>
    ///技能ID 
    /// </summary>

    public string name;

    public string description;

    public int coolTime;
    /// <summary>
    ///技能冷却时间
    /// </summary>

    public int coolTimeRemain;
    /// <summary>
    ///技能冷却时间剩余
    /// </summary>

    public float attackDistance;
    /// <summary>
    ///攻击距离
    /// </summary>

    public float attackAngle;
    /// <summary>
    ///攻击角度
    /// </summary>
    /// 

    public Transform[] attackTargets;
    ///收到攻击目标
    ///

    public string[] impactType = { "CostSP", "Damage" };

    public string prefabName;///预制件名称

    public GameObject skillPrefab;///技能预制件名称

    public string animationName;///收击特效名称
    public GameObject hitFxPrefab;

    public int level;

    public SkillAttackType attackType;
    public SelectorType selectorType;
}
