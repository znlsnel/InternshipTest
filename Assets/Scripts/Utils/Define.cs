using UnityEngine;

public enum ESound
{
    Bgm,
    Effect,
    MaxCount,   
}


#region Interface
public interface IInteractable
{
    GameObject Interact(GameObject gameObject);
}

public interface IDamageable
{
    void TakeDamage(float damage); 
}

public interface IManager
{
    void Init();
    void Clear();
}
#endregion