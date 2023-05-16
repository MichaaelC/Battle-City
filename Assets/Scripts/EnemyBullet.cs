using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage;

    void Start()
    {
        Destroy(gameObject, damage);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Base _base = collision.gameObject.GetComponent<Base>();
        if (_base != null)
        {
            _base.Damage(damage);
            Destroy(gameObject);
        }
        if (collision.GetComponent<Destructable>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        /*else if (collision.GetComponent<PlayerMovement>())
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }*/
        else if (collision.GetComponent<Indestructable>())
        {
            Destroy(gameObject);
        }
    }
}
