using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public enum Direction
{ up, down, left, right };

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private PlayerShoot ps;
    private Vector2 direction;
    private Direction dir = 0;
    private Direction tempDir = 0;

    private float moveSpeedOriginal;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerShoot>();
        moveSpeedOriginal = moveSpeed;
    }

    public void ModifySpeed(float multiplier)
    {
        moveSpeed *= multiplier;
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
        if(dir != tempDir)
        {
            switch (dir)
            {
                case Direction.up:
                    transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                        tempDir = Direction.up;
                    break;
                case Direction.down:
                    transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                        tempDir = Direction.down;
                    break;
                case Direction.left:
                    transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                        tempDir = Direction.left;
                    break;
                case Direction.right:
                    transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                        tempDir = Direction.right;
                    break;
            }
        }
    }

    public void MoveSpeedReset()
    {
        moveSpeed = moveSpeedOriginal;
    }

    public void OnMove(InputValue value)
    {
        //has reference in input system
        direction = value.Get<Vector2>();
        
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal movement is greater than vertical
            if (direction.x > 0)
            {
                direction = Vector2.right;
                dir = Direction.right;
            }
            else
            {
                direction = Vector2.left;
                dir = Direction.left;
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            // Vertical movement is greater than or equal to horizontal
            if (direction.y > 0)
            {
                direction = Vector2.up;
                dir = Direction.up;
            }
            else
            {
                direction = Vector2.down;
                dir = Direction.down;
            }
        }

        if (Mathf.Abs(direction.x) == Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                direction = Vector2.right;
                dir = Direction.right;
            }
            else if (direction.x < 0)
            {
                direction = Vector2.left;
                dir = Direction.left;
            }
        }


        Debug.Log(direction);
        
    }

    public void OnFire()
    {
        //has reference in input system
        ps.Shoot(dir);
    }
}