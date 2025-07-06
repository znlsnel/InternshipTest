using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WeaponHandler), typeof(ResourceHandler))]
public class MonsterController : Entity
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private ResourceHandler resourceHandler;
    private BoxCollider2D boxCollider;
    private GameObject player; 
    private bool isDead = false;
    

    public event Action onSpawn;
    public event Action onDead;
    public event Action onHit;

    private void Awake()
    {
        spriteRenderer = gameObject.FindChild<SpriteRenderer>("Sprite"); 
        boxCollider = GetComponent<BoxCollider2D>();    
        resourceHandler = GetComponent<ResourceHandler>();
    }

    private void Start()
    {
        player = PlayerController.player;
        resourceHandler.Hp.OnResourceChanged += OnHpChanged;

        Setup();
    } 

    public void Setup()
    {
        resourceHandler.Hp.Init(); 
        isDead = false;  
        onSpawn?.Invoke(); 
        boxCollider.enabled = true; 
    }

    private void OnHpChanged(float current, float max)
    {
        if (current <= 0 && !isDead) 
        {
            isDead = true;
            onDead?.Invoke(); 
 
            boxCollider.enabled = false;   
        }
        else
            onHit?.Invoke();
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
