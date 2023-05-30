using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{ up, down, left, right };

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    
    private float moveSpeedOriginal;
    
    private Rigidbody2D rb;
    private PlayerShoot ps;
    private Vector2 direction;
    private Direction dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerShoot>();
        moveSpeedOriginal = moveSpeed;
    }

    public void IncreaseSpeed(float multiplier)
    {
        moveSpeed *= multiplier;
    }

    public void ResetSpeed(float multiplier)
    {
        moveSpeed = multiplier;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        rb.velocity = direction * moveSpeed;
        FaceDirection();
    }

    private void FaceDirection()
    {
        if (direction.x == 1 && direction.y == 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 270f);
            dir = Direction.right;
        }
        else if (direction.x == -1 && direction.y == 0)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 90f);
            dir = Direction.left;   
        }
        else if (direction.x == 0 && direction.y == 1)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);

            dir = Direction.up;
        }
        else if (direction.x == 0 && direction.y == -1)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 180f);
            dir = Direction.down;
        }
    }

    public void MoveSpeedReset()
    {
        moveSpeed = moveSpeedOriginal;
    }

    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
    }

    public void OnFire(InputValue input)
    {
        ps.Shoot(dir);
    }


}