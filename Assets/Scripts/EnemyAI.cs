using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float maxRaycastDistance = 1f;
    public float avoidanceForce = 5f;
    public float moveSpeed = 3f;

    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 currentPos = transform.position;
        Vector2 targetPos = currentPos + new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)).normalized;
        Vector2 moveDirection  = (targetPos - currentPos).normalized;

        if(Mathf.Abs(moveDirection.x) > Mathf.Abs(moveDirection.y))
        {
            moveDirection.y = 0f;
        }
        else
        {
            moveDirection.x = 0f;
        }

        Vector2 newPosition = currentPos + moveDirection * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, moveDirection, maxRaycastDistance);
        if(hit.collider != null)
        {
            float distanceToObstacle = hit.distance;
            if(distanceToObstacle < maxRaycastDistance)
            {
                Vector2 avoidanceDirection = Vector2.Perpendicular(hit.normal);
                rb.AddForce(avoidanceDirection * avoidanceForce);
            }
        }
    }
}
