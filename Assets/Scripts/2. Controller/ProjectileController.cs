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

    float startTime = 0f;

    public void Setup(Vector3 position, GameObject target, LayerMask targetLayer, float speed, float damage, Action onHit)
    {
        transform.position = position;
        targetDir = (target.transform.position - position).normalized;
        
        startTime = Time.time;
        this.onHit = onHit;
        this.speed = speed;
        this.damage = damage;
        this.targetLayer = targetLayer;
    }

    public void Update()
    {
        transform.position += targetDir * speed * Time.deltaTime;

        if (startTime + 10f < Time.time)
            onHit?.Invoke(); 
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
        }
    }

}
