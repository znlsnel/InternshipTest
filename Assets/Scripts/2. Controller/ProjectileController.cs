using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float speed;
    private float damage;
    
    private Vector3 targetDir;
    private LayerMask targetLayer;
    
    public event Action onHit;

    public void Setup(Vector3 position, GameObject target, LayerMask targetLayer, float speed, float damage)
    {
        transform.position = position;
        targetDir = (target.transform.position - position).normalized;
        
        this.speed = speed;
        this.damage = damage;
        this.targetLayer = targetLayer;
    }

    public void Update()
    {
        transform.position += targetDir * speed * Time.deltaTime;
        
    }
 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.IsInLayer(targetLayer)) 
        {
            if (other.TryGetComponent(out IDamageable damagable))
            { 
                damagable.TakeDamage(damage); 
                onHit?.Invoke(); 
            }

            Destroy(gameObject);
        }
    }

}
