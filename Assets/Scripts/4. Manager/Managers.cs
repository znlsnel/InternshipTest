
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Managers : Singleton<Managers>
{ 
    #region Manager Class
    private DataManager data = new DataManager();
    private ResourceManager resource = new ResourceManager();
    private UIManager ui = new UIManager();
    private PoolManager pool = new PoolManager();
    private SoundManager sound = new SoundManager();  
    private GameManager game = new GameManager();

    [SerializeField] private InputManager input;
 
    public static DataManager Data => Instance.data;
    public static ResourceManager Resource => Instance.resource;
    public static SoundManager Sound => Instance.sound; 
    public static UIManager UI => Instance.ui;
    public static PoolManager Pool => Instance.pool;
    public static InputManager Input => Instance.input;
    public static GameManager Game => Instance.game;
    #endregion


    public static event Action onInit;
    private static bool isInit = false;

    protected override void Awake()
    {
        base.Awake();
        

        if (isDestroy)
            return; 

        Init(); 
    }



    private void Init() 
    {

        Resource.Init(); 
        Data.Init();
        Sound.Init();  
        UI.Init();
        Pool.Init();
        Input.Init();
        Game.Init();


        isInit = true;
        onInit?.Invoke(); 
        onInit = null;
    }


    public void OnDestroy()
    {
        Clear();
    }

    public void Clear()
    {
        Resource.Clear(); 
        Data.Clear();
        Game.Clear();
        Sound.Clear();  
        UI.Clear();
        Pool.Clear();
        Input.Clear();
    } 

    public static void SubscribeToInit(Action callback)
    {
        if (isInit)
            callback?.Invoke();
        else
            onInit += callback;  
    }


}
