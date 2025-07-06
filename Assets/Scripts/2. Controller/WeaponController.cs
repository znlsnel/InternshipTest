using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField] private Transform muzzle;
    [SerializeField] private ProjectileController projectilePrefab;
    [SerializeField] private CircleCollider2D circleCollider;

    [field : SerializeField] public float Damage {get; private set;} = 10;
    [field : SerializeField] public float AttackSpeed {get; private set;} = 1;
    [field : SerializeField] public float ProjectileSpeed {get; private set;} = 10;
    [field : SerializeField]public float AttackRange {get; private set;} = 10;
    
    private HashSet<GameObject> targets = new HashSet<GameObject>();
    private LayerMask targetLayer;

    private GameObject target;

    private float attackTimer = 0;


    private void OnEnable()
    {
        StartCoroutine(FindTarget()); 
    } 



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
        

        Rotate();
        Shoot();


        
    }

    private void Rotate()
    {
        if (target == null)
            return;

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - transform.position.x) * Mathf.Rad2Deg);
    }

    private void Shoot()
    {
        if (target == null)
            return;

        if (targets.Count > 0 && attackTimer + AttackSpeed < Time.time) 
        {
            Instantiate(projectilePrefab, muzzle.position, Quaternion.identity).Setup(muzzle.position, target, targetLayer, ProjectileSpeed, Damage);
            attackTimer = Time.time;
        }
    }



    private IEnumerator FindTarget(float interval = 0.1f)
    {
        while (true)
        {
            target = null;
            float nearestDistance = float.MaxValue;

            foreach (var t in targets.ToArray())
            {
                if (t.GetComponent<ResourceHandler>().Hp.current <= 0)  
                {
                    targets.Remove(t);  
                    continue;
                }

                float distance = Vector3.Distance(transform.position, t.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    target = t;
                }
            }

            yield return new WaitForSeconds(interval); 
        }
        
    }
}
