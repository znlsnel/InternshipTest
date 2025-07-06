using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Analytics;
using Object = UnityEngine.Object;

[Serializable]
public class ResourceManager : IManager
{    
    private Dictionary<string, UnityEngine.Object> _resources = new Dictionary<string, UnityEngine.Object>();
    
    public void Init() 
    {
        
    }

 
    public void Clear()
    {
        foreach (var resource in _resources.Values)
            Object.Destroy(resource); 
        
        _resources.Clear();
    }

    public T Load<T>(string key) where T : UnityEngine.Object
    {
        if (!_resources.TryGetValue(key, out Object obj))
        {
            obj = Resources.Load<T>(key);
            if (obj == null)
            {
                Debug.LogError($"Failed to load prefab : {key}");
                return null;
            }

            _resources[key] = obj;
        }
        return obj as T; 
    }
    
    public T Instantiate<T>(string key, Transform parent = null) where T : UnityEngine.Object
    {
        GameObject prefab = Instantiate(key, parent);
        if (prefab == null)
            return null;

        return prefab.GetComponent<T>();
    }

    public GameObject Instantiate(string key, Transform parent = null)
    {
        if (!_resources.TryGetValue(key, out Object obj))
        {
            obj = Resources.Load<GameObject>(key); 
            _resources[key] = obj;
        }
        

        if (obj == null)
        {
            Debug.LogError($"인스턴스화 실패 : {key}");
            return null;
        }

        return Object.Instantiate(obj as GameObject, parent); 
    }

}
