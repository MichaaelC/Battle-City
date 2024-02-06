using UnityEngine;

public class MoveRightPlayer : MonoBehaviour
{
    private float moveSpeed = 1f;

    private void FixedUpdate()
    {
        transform.Translate(Vector3.right * moveSpeed);
    }
}
