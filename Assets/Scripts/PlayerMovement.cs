using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction { up, down, left, right};

public class PlayerMovement : MonoBehaviour
{
    Vector2 direction;
    Rigidbody2D rb;
    BoxCollider2D col;
    Transform tf;
    PlayerShoot ps;
    [SerializeField] private float moveSpeed = 3f;
    Direction dir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        tf = GetComponent<Transform>();
        ps = GetComponent<PlayerShoot>();
    }

    void Update()
    {
       
        
    }

    private void FixedUpdate()
    {
        
        Movement();
    }

    private void FaceDirection()
    {
        if (direction.x == 1 && direction.y == 0) 
        {
            tf.eulerAngles = (new Vector3(0f, 0f, 270f));
            dir = Direction.right;
        }
        else if (direction.x == -1 && direction.y == 0) 
        {
            tf.eulerAngles = (new Vector3(0f, 0f, 90f));
            dir = Direction.left;
            
        }
        else if (direction.x == 0 && direction.y == 1) 
        {
            tf.eulerAngles = (new Vector3(0f, 0f, 0f));
            
            dir = Direction.up;
        }
        else if (direction.x == 0 && direction.y == -1) 
        {
            tf.eulerAngles = (new Vector3(0f, 0f, 180f));
            dir = Direction.down;
            
        }
    }

    void Movement()
    {
        rb.velocity = direction * moveSpeed;
        FaceDirection();
    }
    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
        Debug.Log(direction);
    }

    public void OnFire(InputValue input)
    {
        Debug.Log(input.Get<float>());
        ps.Shoot(dir);
    }
}
