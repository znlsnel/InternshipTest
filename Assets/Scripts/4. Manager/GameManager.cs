using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;


public class GameManager : IManager
{
    public event Action onGameStart;
    public void Init()
    {
        
    }

    public void Clear()
    {

    }


    public void GameStart()
    {
        GameObject player = Managers.Resource.Instantiate("Player/Player");
        player.transform.position = Vector3.zero;

        onGameStart?.Invoke(); 
    }

}
