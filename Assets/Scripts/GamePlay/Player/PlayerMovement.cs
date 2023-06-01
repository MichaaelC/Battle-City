using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{ up, down, left, right };

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private PlayerShoot ps;
    private Vector2 direction;
    private Direction dir;

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
        //has reference in input system
        direction = value.Get<Vector2>();
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            // Horizontal movement is greater than vertical
            if (direction.x > 0)
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.left;
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            // Vertical movement is greater than or equal to horizontal
            if (direction.y > 0)
            {
                direction = Vector2.up;
            }
            else
            {
                direction = Vector2.down;
            }
        }
        else
        {
            direction = Vector2.zero;
        }
    }

    public void OnFire()
    {
        //has reference in input system
        ps.Shoot(dir);
    }
}