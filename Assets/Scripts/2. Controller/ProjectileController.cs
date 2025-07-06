using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private float speed;
    private float damage;
    
    private Vector3 targetDir;
    private GameObject target;

    public void Setup(Vector3 position, GameObject target, float speed, float damage)
    {
        transform.position = position;
        targetDir = (target.transform.position - position).normalized;
        
        this.target = target;
        this.speed = speed;
        this.damage = damage;

    }

    public void Update()
    {
        transform.position += targetDir * speed * Time.deltaTime;
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == target)
        { 
            if (target.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }

}
