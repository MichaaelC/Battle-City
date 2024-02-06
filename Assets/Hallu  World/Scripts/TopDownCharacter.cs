using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TopDownCharacter : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput = new();
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveInput.normalized * moveSpeed;
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}







