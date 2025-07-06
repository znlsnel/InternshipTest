using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


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
        onGameStart?.Invoke(); 
    }

}
