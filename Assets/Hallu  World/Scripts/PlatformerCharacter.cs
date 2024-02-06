using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerCharacter : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private LayerMask groundLayer;
    public float groundCheckRadius = 0.5f;
    public float groundCheckYAxisOffset = 2f;
    Vector2 circleCenter;

    private Rigidbody2D rb;
    private bool isGrounded;
    float moveInput = 0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Check if the character is grounded
        IsGrounded();

    }
    private void IsGrounded()
    {
        circleCenter.x = transform.position.x;
        circleCenter.y = transform.position.y - groundCheckYAxisOffset;
        isGrounded = Physics2D.OverlapCircle(circleCenter, groundCheckRadius, groundLayer);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
    }

    private void OnJump()
    {
        Jump();
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        Vector2 circleCenter = new Vector2(transform.position.x, transform.position.y - groundCheckYAxisOffset);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(circleCenter, groundCheckRadius);
    }
}
