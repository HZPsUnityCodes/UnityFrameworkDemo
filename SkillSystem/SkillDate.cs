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
    ///����ID 
    /// </summary>

    public string name;

    public string description;

    public int coolTime;
    /// <summary>
    ///������ȴʱ��
    /// </summary>

    public int coolTimeRemain;
    /// <summary>
    ///������ȴʱ��ʣ��
    /// </summary>

    public float attackDistance;
    /// <summary>
    ///��������
    /// </summary>

    public float attackAngle;
    /// <summary>
    ///�����Ƕ�
    /// </summary>
    /// 

    public Transform[] attackTargets;
    ///�յ�����Ŀ��
    ///

    public string[] impactType = { "CostSP", "Damage" };

    public string prefabName;///Ԥ�Ƽ�����

    public GameObject skillPrefab;///����Ԥ�Ƽ�����

    public string animationName;///�ջ���Ч����
    public GameObject hitFxPrefab;

    public int level;

    public SkillAttackType attackType;
    public SelectorType selectorType;
}
