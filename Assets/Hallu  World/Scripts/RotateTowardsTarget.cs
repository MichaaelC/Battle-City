using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class RotateTowardsTarget : MonoBehaviour
{
    public float rotationSpeed = 5f;

    private Transform target;

    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = target.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (target == null && !collision.GetComponent<RotateTowardsTarget>())
        {
            target = collision.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (target == collision.transform)
        {
            target = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, target != null ? target.position : transform.position);
    }
}
