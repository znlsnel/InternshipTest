using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponHandler), typeof(ResourceHandler))]
public class MonsterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    GameObject player;

    private ResourceHandler resourceHandler;
    private bool isDead = false;

    private void Start()
    {
        player = PlayerController.player;
        resourceHandler = GetComponent<ResourceHandler>();

        resourceHandler.Hp.OnResourceChanged += OnHpChanged;
    }

    private void OnHpChanged(float current, float max)
    {
        if (current <= 0 && !isDead) 
        {
            isDead = true;
        }
    }

    private void Update()
    {
        if (player == null || isDead) 
            return;


        Vector3 dir = (player.transform.position - transform.position).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;
        spriteRenderer.flipX = dir.x < 0; 
    }

}
