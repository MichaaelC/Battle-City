using UnityEngine;
using UnityEngine.InputSystem;

public enum Direction
{ up, down, left, right };

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float moveSpeedOriginal;
    private Vector2 direction;
    private Rigidbody2D rb;
    private BoxCollider2D col;
    private Transform tf;
    private PlayerShoot ps;
    private Direction dir;

    public float currentSpeed;
    public float increasedSpeed = 10f;
    //private int currentFirePower;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        tf = GetComponent<Transform>();
        ps = GetComponent<PlayerShoot>();
        moveSpeedOriginal = moveSpeed;
        currentSpeed = moveSpeed;
    }
    
    private void FixedUpdate()
    {
        Movement();
    }

    public void IncreaseSpeed()
    {
        currentSpeed = increasedSpeed;
    }
    
    private void FaceDirection()
    {
        if (direction.x == 1 && direction.y == 0)
        {
            tf.eulerAngles = new Vector3(0f, 0f, 270f);
            dir = Direction.right;
        }
        else if (direction.x == -1 && direction.y == 0)
        {
            tf.eulerAngles = new Vector3(0f, 0f, 90f);
            dir = Direction.left;   
        }
        else if (direction.x == 0 && direction.y == 1)
        {
            tf.eulerAngles = new Vector3(0f, 0f, 0f);

            dir = Direction.up;
        }
        else if (direction.x == 0 && direction.y == -1)
        {
            tf.eulerAngles = new Vector3(0f, 0f, 180f);
            dir = Direction.down;
        }
    }

    private void Movement()
    {
        rb.velocity = direction * moveSpeed;
        FaceDirection();
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