using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeedMin = 0.1f;
    public float moveSpeedMax = 0.6f;
    private float moveSpeed = 0f;

    private void Awake()
    {
        moveSpeed = Random.Range(moveSpeedMin, moveSpeedMax);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * moveSpeed);
    }
}
