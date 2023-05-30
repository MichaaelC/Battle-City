using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject explosion;
   

    [SerializeField] private Vector2 explosionRadius = new Vector2(1f, 1f);
    private List<Collider2D> explosionHits;

    void Start()
    {
        Invoke("Explode", timer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        explosionHits = Physics2D.OverlapBoxAll(transform.position, explosionRadius, 0f).ToList();

        foreach (var item in explosionHits)
        {
            if (item.gameObject.GetComponent<HealthBase>())
            {
                item.GetComponent<HealthBase>().GetDamage(damage);
                Hit();
            }
            else if (item.GetComponent<HealthDestructable>())
            {
                item.GetComponent<HealthDestructable>().GetDamage(damage);
                Hit();
            }
            else if(item.GetComponent<HealthEnemy>()) 
            {
                item.GetComponent<HealthEnemy>().GetDamage(damage);
                Hit();
            }
            else if (item.GetComponent<EnemyBullet>())
            {
                item.GetComponent<EnemyBullet>().Hit();
            }
            else if (item.GetComponent<HealthIndestructable>() || item.GetComponent<Wall>())
            {
                Explode();
            } 
        }
        explosionHits.Clear();
    }

    public void Hit()
    {
        health--;
        if (health <= 0)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Debug.Log("asd");
        GameObject bulletExplosion = Instantiate(explosion, transform, true);
        Debug.Log(bulletExplosion);
        Destroy(this.gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, explosionRadius);
    }
}
