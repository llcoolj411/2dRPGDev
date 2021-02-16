using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    ATTACK,
    DEFFENCE,
    SPEED1,
    SPEED2,
    COMBO,
    COMBO2
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

        if (skillType == SkillType.SPEED2)
        {
            return HasSkill(SkillType.SPEED1);
        }
        return true;
    }

    public void SkillLearn(SkillType skillType)
    {
        SkillList.Add(skillType);
    }
}
