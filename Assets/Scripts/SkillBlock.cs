using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBlock : MonoBehaviour
{
    SkillType skillType;
    [SerializeField] int cost;
    [SerializeField] new string name;
    [SerializeField] string info;

    public void OnClick()
    {
        //習得済みなら何もしない
        if (SkillManager.instance.HasSkill(this.skillType))
        {
            Debug.Log("習得済みです");
            return;
        }

        //習得可能か（すでにスキルを持っていないか）

        //習得可能なら習得する:スキルポイントが足りている＆前提スキルを持っている
        if (SkillManager.instance.CanLearnSkill(cost,skillType))
        {
            SkillManager.instance.SkillLearn(this.skillType);
            Debug.Log("習得！");
        }
        else
        {
            Debug.Log("習得NG");
        }
        //習得不可能ならログを出す


    }
}
