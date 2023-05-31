using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private Vector2 explosionRadius = new (1f, 1f);
    private List<Collider2D> explosionHits;

    private void Start()
    {
        Invoke(nameof(Explode), timer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<HealthBase>())
        {
            Hit();
            collision.GetComponent<HealthBase>().GetDamage(damage);
        }
        else if (collision.GetComponent<HealthDestructable>())
        {
            Hit();
            collision.GetComponent<HealthDestructable>().GetDamage(damage);
        }
        else if (collision.GetComponent<HealthPlayer>())
        {
            Hit();
            collision.GetComponent<HealthPlayer>().GetDamage(damage);
        }
        else if (collision.GetComponent<PlayerBullet>())
        {
            collision.GetComponent<PlayerBullet>().Hit();
            Hit();
        }
        else if (collision.GetComponent<HealthIndestructable>() || collision.GetComponent<Wall>())
        {
            Explode();
        }
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
        explosionHits = Physics2D.OverlapBoxAll(transform.position, explosionRadius, 0f).ToList();
        foreach (var item in explosionHits)
        {
            if (item.gameObject.GetComponent<HealthBase>())
            {
                item.GetComponent<HealthBase>().GetDamage(damage);
            }
            else if (item.GetComponent<HealthDestructable>())
            {
                item.GetComponent<HealthDestructable>().GetDamage(damage);
            }
            else if (item.GetComponent<HealthPlayer>())
            {
                item.GetComponent<HealthPlayer>().GetDamage(damage);
            }
            else if (item.GetComponent<PlayerBullet>())
            {
                item.GetComponent<PlayerBullet>().Hit();
            }
        }
        explosionHits.Clear();
        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void ModifyBullet(int damageValue, int healthValue)
    {
        this.damage += damageValue;
        this.health += healthValue;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, explosionRadius);
    }
}