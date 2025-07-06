using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 예시 테이블 -> 아이템 같은


public class DataManager : IManager
{
    public Dictionary<string, MonsterData> monsterData = new Dictionary<string, MonsterData>();
    
    public void Init()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("JSON/MonsterData");
        MonsterDatas monsterData = JsonUtility.FromJson<MonsterDatas>(textAsset.text);

        foreach (MonsterData data in monsterData.Monster)
        {
            this.monsterData.Add(data.MonsterID, data);
        }
    }

    public void Clear()
    {
        
    }



}
