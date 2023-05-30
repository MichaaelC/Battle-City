using System.Collections;
using UnityEngine;

public class EnemyMoveAI : MonoBehaviour
{
	public float movementSpeed = 5.0f;

    [SerializeField] private float minChangeDirectionTime = 0.5f;
    [SerializeField] private float maxChangeDirectionTime = 3.0f; 
	[SerializeField] private float raycastDistance = 1f;

	[SerializeField] private bool canRotate = true;
	[SerializeField] private bool canMove = true;

	private Rigidbody2D rb;
	private Collider2D col;
	private Vector2 movementDirection; 
	private Vector3 originalMovement;
	private RaycastHit2D hit;
	private LayerMask foreGroundLayerMask;

	private float angle;
    private float moveSpeedOriginal;
	private bool isFrozen = false;

	private WaitForSeconds wait;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        foreGroundLayerMask = LayerMask.GetMask("Foreground");
		movementDirection = Vector2.down;
		moveSpeedOriginal = movementSpeed;

        wait = new(1f);
    }

    private void Start()
	{   
		originalMovement = rb.velocity;
        movementDirection = RandomDirection();
        StartCoroutine(ChangeDirection());
	}

	private void Update()
    {
		col.enabled = false;
        hit = Physics2D.Raycast(transform.position, movementDirection, raycastDistance, foreGroundLayerMask);
		col.enabled = true;

		if(hit.collider != null)
		{
			CheckFront(hit);
		}
		else
		{
			CanMoveAndRotate(true, true);
        }
    }

	private void CheckFront(RaycastHit2D hit)
    {
		if(hit.collider.gameObject.GetComponent<HealthBase>() != null)
		{
			CanMoveAndRotate(false, false);
		}
		else if (
			hit.collider.gameObject.GetComponent<HealthDestructable>() != null ||
			hit.collider.gameObject.GetComponent<HealthIndestructable>() != null ||
			hit.collider.gameObject.GetComponent<HealthPlayer>() != null ||
			hit.collider.gameObject.GetComponent<HealthEnemy>() != null)
		{
			CanMoveAndRotate(false, true);
		}
        else
        {
			CanMoveAndRotate(true, true);
        }
    }

    void FixedUpdate()
	{
		rb.velocity = movementDirection * movementSpeed;		
		angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}

	private IEnumerator ChangeDirection()
	{
		while (true)
		{
			yield return wait;
            movementDirection = RandomDirection();

			wait = new(Random.Range(minChangeDirectionTime, maxChangeDirectionTime));
        }
    }

	private Vector2 RandomDirection()
	{
		if (canRotate)
		{
			int rand = Random.Range(0, 4);
			switch (rand)
			{
				case 0:
					return Vector2.down;
				case 1:
					return Vector2.up;
				case 2:
					return Vector2.left;
				case 3:
					return Vector2.right;
				default:
					return movementDirection;
			}
		}
		return movementDirection;
	}

	public void MoveSpeedRestart()
	{
		movementSpeed = moveSpeedOriginal;
	}

	public void Freeze(float duration)
	{
		if (!isFrozen)
		{
			isFrozen = true;
			rb.velocity = Vector3.zero;
			Invoke(nameof(ResumeAI), duration);
		}
	}

	private void ResumeAI()
	{
		isFrozen = false;
		rb.velocity = originalMovement;
	}

    private void CanMoveAndRotate(bool move, bool rotate)
    {
        canMove = move;
        canRotate = rotate;
    }

    public void DestroyEnemy()
	{
		Destroy(gameObject);
	}

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, (Vector2) transform.position + movementDirection.normalized * raycastDistance);
    }
}
