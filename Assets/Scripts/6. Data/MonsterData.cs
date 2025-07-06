using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterDatas
{
    public List<MonsterData> Monster;  
}


[System.Serializable]
public class MonsterData
{
    [Header("기본 정보")]
    public string MonsterID;
    public string Name;
    public string Description;
    
    [Header("공격 관련")]
    public int Attack;
    public float AttackMul;
    public int AttackRange;
    public float AttackRangeMul;
    public int AttackSpeed;
    
    [Header("생존 관련")]
    public int MaxHP;
    public float MaxHPMul;
    public int MoveSpeed;
    
    [Header("보상 관련")]
    public int MinExp;
    public int MaxExp;
    public int DropItem;
}
