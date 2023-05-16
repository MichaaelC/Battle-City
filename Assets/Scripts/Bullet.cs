using Unity.Burst;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    
    private void Start()
    {
        Destroy(gameObject, damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AI enemy = collision.gameObject.GetComponent<AI>();
   
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }
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