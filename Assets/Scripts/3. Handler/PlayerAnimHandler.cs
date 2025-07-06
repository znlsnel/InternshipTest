using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimHandler : MonoBehaviour
{
    private static readonly int IsMove = Animator.StringToHash("Run");
    private static readonly int IsDead = Animator.StringToHash("Dead");

    private Animator animator;
    private PlayerController playerController;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();

        playerController.onMove += SetMove; 
    }

    public void SetMove(bool isMove)
    {
        animator.SetBool(IsMove, isMove);
    }

    public void SetDead(bool isDead)
    {
        animator.SetBool(IsDead, isDead); 
    }
}
