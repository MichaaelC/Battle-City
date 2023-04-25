using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life = 3;

    private void Start()
    {
        Destroy(gameObject, life);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Destructable>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.GetComponent<Indestructable>())
        {
            Destroy(gameObject);
        }
    }
}