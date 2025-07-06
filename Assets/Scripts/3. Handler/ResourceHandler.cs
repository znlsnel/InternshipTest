using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class ResourceHandler : MonoBehaviour, IDamageable
{
    [field : SerializeField] private Stat hp;

    public Stat Hp {get {return hp;}}

    public void TakeDamage(float damage)
    {
        hp.Subtract(damage);
    }
}
