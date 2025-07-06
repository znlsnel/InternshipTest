using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    [SerializeField] private WeaponController weaponPrefab;

    public LayerMask TargetLayer {get {return targetLayer;}}

    private void Start()
    {
        if (weaponPrefab != null)
            Instantiate(weaponPrefab, transform).Setup(targetLayer);  
    }
    
}
