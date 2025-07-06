using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private SpriteRenderer sprite;

    // Event
    public event Action<bool> onMove;

    // Input
    private InputAction Click;
    private InputAction Pointer;


    // Data
    private Vector3 startPos = Vector3.zero;
    private Vector3 mousePos = Vector3.zero;

    private bool isMove = false;


    private void Start()
    {
        Click = Managers.Input.Click;
        Pointer = Managers.Input.Pointer;

        Click.started += OnClick;
        Click.canceled += OnClick;

        Pointer.performed += OnPointer;
    }

    private void Update()
    {
        if (isMove)
            OnMove();
    }

    private void OnClick(InputAction.CallbackContext obj)
    {
        isMove = obj.phase == InputActionPhase.Started;
        if (isMove)
        {
            startPos = Input.mousePosition;
            mousePos = startPos; 
        }
        else
        {
            onMove?.Invoke(false); 
        }
    }


    private void OnPointer(InputAction.CallbackContext obj)
    {
        if (!isMove)
            return;

        mousePos = obj.ReadValue<Vector2>();
    }


    private void OnMove()
    {
        if (Vector3.Distance(mousePos, startPos) < 0.1f) 
            return;

        onMove?.Invoke(true);  
        Vector3 dir = (mousePos - startPos).normalized;
        transform.position += dir * moveSpeed * Time.deltaTime;

        sprite.flipX = dir.x < 0; 
    }
}
