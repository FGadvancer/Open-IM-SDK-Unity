using UnityEngine;
using System;

public enum SkillType
{
    // 单击
    Single,
    // 连击,
    Combo,
}


[Serializable]
public class SkillConfig
{
    // 技能名
    public string Name;
    // 动画名
    public AnimationClip Anim;
    // 消耗体力
    public float CostVit;
    // 优先级
    public int Priority;
    // 攻击
    public float Attack;
    // 防御
    public float Defend;
    // 攻击次数
    public int HitNumber;
    // 是否击飞
    public bool HitFly;
}