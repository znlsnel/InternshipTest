using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimHandler : MonoBehaviour
{
    private static readonly int Hit = Animator.StringToHash("Hit");
    private static readonly int IsDead = Animator.StringToHash("Dead");

    private MonsterController monsterController;
    private Animator animator;

    private void Awake()
    {
        monsterController = GetComponent<MonsterController>();
        animator = GetComponentInChildren<Animator>();

        monsterController.onHit += SetHit;
        monsterController.onDead += SetDead; 
        monsterController.onSpawn += SetSpawn; 
    }

    public void SetHit()
    {
        animator.SetTrigger(Hit);
    }

    public void SetDead()
    {
        animator.SetBool(IsDead, true);  
    }
    
    public void SetSpawn()
    {
        animator.SetBool(IsDead, false);  
    }
}
