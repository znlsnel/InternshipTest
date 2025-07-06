using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimHandler : MonoBehaviour
{
    private static readonly int Hit = Animator.StringToHash("Hit");
    private static readonly int IsDead = Animator.StringToHash("Dead");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void SetHit()
    {
        animator.SetTrigger(Hit);
    }

    public void SetDead(bool isDead)
    {
        animator.SetBool(IsDead, isDead);  
    }
}
