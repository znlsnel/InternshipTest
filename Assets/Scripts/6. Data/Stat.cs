using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Stat
{
    [field : SerializeField] public float value {get; private set;} = 100;
    [field : SerializeField] public float current {get; private set;} = 100;

    private float addValue = 0;
    private float maxValue => value + addValue;

    public event Action<float, float> OnResourceChanged; // (current, max)
    
    public Dictionary<GameObject, int> items = new Dictionary<GameObject, int>();

    public void Init()
    {
        current = value;
    }

    public void Add(float amount)
    {
        current += amount;
        current = Mathf.Clamp(current, 0, maxValue);

        OnResourceChanged?.Invoke(current, maxValue);
    }

    public void Subtract(float amount)
    {
        current -= amount;
        current = Mathf.Clamp(current, 0, maxValue);
        
        OnResourceChanged?.Invoke(current, maxValue);
    }

    public void Modify(float amount)
    {
        current = amount;
        current = Mathf.Clamp(current, 0, maxValue); 

        OnResourceChanged?.Invoke(current, maxValue);
    }

    public void AddItem(GameObject item, int amount)
    {
        addValue += amount;
        items.Add(item, amount);
        OnResourceChanged?.Invoke(current, maxValue);
    }

    public void RemoveItem(GameObject item)
    {
        if (items.ContainsKey(item))
        {
            addValue -= items[item];
            items.Remove(item);
            OnResourceChanged?.Invoke(current, maxValue);
        }

    }
}
