using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private ProjectileController projectilePrefab;
    [SerializeField] private CircleCollider2D circleCollider;

    [field : SerializeField] public float Damage {get; private set;} = 10;
    [field : SerializeField] public float AttackSpeed {get; private set;} = 1;
    [field : SerializeField] public float ProjectileSpeed {get; private set;} = 10;
    [field : SerializeField]public float AttackRange {get; private set;} = 10;
    
    private HashSet<GameObject> targets = new HashSet<GameObject>();
    private LayerMask targetLayer;


    private float attackTimer = 0;

    public void Setup(LayerMask layer)
    {
        targetLayer = layer;
        AttackSpeed = 1f / AttackSpeed; 
        circleCollider.radius = AttackRange; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (targetLayer.value == (targetLayer.value | (1 << other.gameObject.layer)))
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
                targets.Add(other.gameObject);
        }
    }

     
    private void OnTriggerExit2D(Collider2D other)
    {
        if (targetLayer.value == (targetLayer.value | (1 << other.gameObject.layer)))
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
                targets.Remove(other.gameObject);
        }
    }

    private void Update()
    {
        if (targets.Count > 0 && attackTimer + AttackSpeed < Time.time) 
        {
            GameObject target = GetNearestTarget();
            Instantiate(projectilePrefab, transform.position, Quaternion.identity).Setup(transform.position, target, ProjectileSpeed, Damage);
            attackTimer = Time.time;
        } 
    }


    private GameObject GetNearestTarget()
    {
        GameObject nearestTarget = null;
        float nearestDistance = float.MaxValue;

        foreach (var target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestTarget = target;
            }
        }

        return nearestTarget; 
    }
}
