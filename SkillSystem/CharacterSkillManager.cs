using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CharacterSkillManager : MonoBehaviour
{

    public SkillData[] skills;
    /// <summary>
    /// 技能列表 
    /// </summary>
    /// 

    ///<summary>初始化技能</summary>

    private void InitSkill(SkillData data) {
        ///获取预制件对象
        data.skillPrefab = Resources.Load<GameObject>("Skill"+ data.prefabName);
    }
    public void GenerateSkill(SkillData data) 
    {
        GameObject skillGo = Instantiate(data.skillPrefab, transform.position,transform.rotation);

        ///Destroy();

        ///技能冷却
        StartCoroutine(CoolTimeDown(data));
    }

    private SkillData Find(Func<SkillData,bool>handler)
    {
        for (int i = 0; i < skills.Length; i++)
        {
            ///if (skills[i].skillID == id)
            if(handler(skills[i]))
                return skills[i];
        }
        return null;
    }
    public SkillData PrepareSkill(int id)
    {
        ///根据ID查找技能数据
        SkillData data = Find(s => s.skillID == id);
        ///判断条件
        if (data != null && data.coolTimeRemain <= 0)
            return data;
        else
            return null;
    }

    private IEnumerator CoolTimeDown(SkillData data)
    {
        data.coolTimeRemain = data.coolTime;
        while (data.coolTimeRemain > 0 ) {
            yield return new WaitForSeconds(1);
            data.coolTimeRemain--;
        }
    }
    // Start is called before the first frame update

    private void OnSkillButtonDown()
    { 
    }
    void Start()
    {
        for (int i = 0; i < skills.Length; i++)
        {
            InitSkill(skills[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
