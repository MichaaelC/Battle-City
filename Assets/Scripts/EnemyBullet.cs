using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    [SerializeField] private int damage = 1;
    [SerializeField] private int health = 1;


    void Start()
    {
        Destroy(gameObject, timer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<HealthBase>())
        {
            collision.GetComponent<HealthBase>().GetDamage(damage);
            Hit();
        }

        else if (collision.GetComponent<HealthDestructable>())
        {
            collision.GetComponent<HealthDestructable>().GetDamage(damage);
            Hit();
        }

        else if(collision.GetComponent<HealthPlayer>()) 
        {
            collision.GetComponent<HealthPlayer>().GetDamage(damage);
            Hit();
        }

        else if (collision.GetComponent<HealthIndestructable>())
        {
            Destroy(gameObject);
        }
    }

    private void Hit()
    {
        health--;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
