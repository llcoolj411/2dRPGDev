using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillBlock : MonoBehaviour
{
    [SerializeField] SkillType skillType;
    [SerializeField] int cost;
    [SerializeField] new string name;
    [SerializeField] string info;
    [SerializeField] GameObject hidepanel;

    void Start()
    {
        CheckActiveBlock();
    }

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
            ChangeLearnedBlock(Color.green);
        }
        else
        {
            //習得不可能ならログを出す
            Debug.Log("習得NG");
        }

        void ChangeLearnedBlock(Color color)
        {
            Image image = GetComponent<Image>();
            image.color = color;

        }
    }

    public void CheckActiveBlock()
    {
        if (SkillManager.instance.CanLearnSkill(cost, skillType))
        {
            hidepanel.SetActive(false);
        }

        else
        {
            hidepanel.SetActive(true);
        }
    }
}
