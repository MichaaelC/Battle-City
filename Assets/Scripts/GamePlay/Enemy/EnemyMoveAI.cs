using System.Collections;
using UnityEngine;

public class EnemyMoveAI : MonoBehaviour
{
	public float movementSpeed = 5.0f; 
	public float minChangeDirectionTime = 1.0f; 
	public float maxChangeDirectionTime = 3.0f; 
	private Rigidbody2D rb; 
	private Vector2 movementDirection; 
	private float timeToChangeDirection; 
	private float moveSpeedOriginal;
	private bool hitEnemy;
	private float raycastDistance = 4f;

	private bool isFrozen = false;
	private Vector3 originalMovement;

	private WaitForSeconds wait;
	void Start()
	{   
		rb = GetComponent<Rigidbody2D>();
		timeToChangeDirection = Time.time + Random.Range(minChangeDirectionTime, maxChangeDirectionTime);       
		movementDirection = Vector2.down;
		moveSpeedOriginal = movementSpeed;
		originalMovement = rb.velocity;
		wait = new(1f);
		StartCoroutine(ChangeDirection());
	}

	void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast(transform.position, movementDirection, raycastDistance, LayerMask.GetMask("Obstacle"));
		
		if (hit.collider != null)
		{
			movementDirection = RandomDirection();
			hitEnemy = true;
		}
		else
		{
			hitEnemy = false;
		}

		if (!isFrozen)
		{
			RandomDirection();
		}
	}

	void FixedUpdate()
	{

		if (!hitEnemy)
		{
			rb.velocity = movementDirection * movementSpeed;
		}
		else
		{
			rb.velocity = Vector2.zero;
		}

		float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg - 90f;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		//rb.velocity = movementDirection * movementSpeed;
	}

	private IEnumerator ChangeDirection()
	{
		while (true)
		{
			yield return wait;
            timeToChangeDirection = Time.time + Random.Range(minChangeDirectionTime, maxChangeDirectionTime);
            movementDirection = RandomDirection();

			wait = new(Random.Range(minChangeDirectionTime, maxChangeDirectionTime));
        }
    }

	private Vector2 RandomDirection()
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
				return Vector2.zero;
		}
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

	public void DestroyEnemy()
	{
		Destroy(gameObject);
	}
}
