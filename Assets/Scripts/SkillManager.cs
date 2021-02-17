using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    Lv1ATTACK,
    Lv2Passive,
    Lv2Active,
    Lv3Passive,
    Lv3Active,
    Lv4Passive

}


public class SkillManager : MonoBehaviour
{
    int skillpoint;
    List<SkillType> SkillList = new List<SkillType>();

    public static SkillManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    public bool HasSkill(SkillType skillType)
    {
        return SkillList.Contains(skillType);
    }

    public bool CanLearnSkill(int cost,SkillType skillType)
    {
        if (skillpoint < cost)
        {
            return false;
        }

        if ((skillType == SkillType.Lv2Passive) || (skillType == SkillType.Lv2Active))
        {
            return HasSkill(SkillType.Lv1ATTACK);
        }

        if (skillType == SkillType.Lv3Passive)
        {
            return HasSkill(SkillType.Lv2Active);
        }

        if (skillType == SkillType.Lv3Active)
        {
            return HasSkill(SkillType.Lv2Passive);
        }

        if (skillType == SkillType.Lv4Passive)
        {
            return HasSkill(SkillType.Lv3Passive) && HasSkill(SkillType.Lv3Active);
        }

        return true;
    }

    public void SkillLearn(SkillType skillType)
    {
        SkillList.Add(skillType);
    }
}
