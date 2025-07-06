using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static bool IsNull => instance == null; 
    protected bool isDestroy = false;

    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // 씬에서 오브젝트 탐색
                instance = FindAnyObjectByType<T>();

                if (instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    instance = obj.AddComponent<T>();
                }

            }
            
            return instance;
        }
    }



    protected virtual void Awake()
    {
        if (instance == null)
            instance = this as T;
        
        else if (instance != this)
        {
            Destroy(gameObject);
            isDestroy = true;
            return;
        }
        
        // 부모 오브젝트가 있을 경우 부모 해제
        if (transform.parent != null)
            transform.SetParent(null);
        
        DontDestroyOnLoad(gameObject);
    }
}
