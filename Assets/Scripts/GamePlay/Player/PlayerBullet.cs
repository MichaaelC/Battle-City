using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Vector2 explosionRadius = new (1f, 1f);
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private float timer = 5f;

    private Collider2D col;
    private List<Collider2D> explosionHits;

    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }

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
        else if (collision.GetComponent<HealthEnemy>())
        {
            Hit(3);
            collision.GetComponent<HealthEnemy>().GetDamage(damage);
        }
        else if (collision.GetComponent<EnemyBullet>())
        {
            Hit();
            collision.GetComponent<EnemyBullet>().Hit(damage);
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
            col.enabled = false;
            Explode();
        }
    }

    public void Hit(int value)
    {
        health -= value;
        if (health <= 0)
        {
            col.enabled = false;
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
            else if (item.GetComponent<HealthEnemy>())
            {
                item.GetComponent<HealthEnemy>().GetDamage(damage);
            }
            else if (item.GetComponent<EnemyBullet>())
            {
                item.GetComponent<EnemyBullet>().Hit(damage);
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
        Gizmos.DrawWireCube(this.transform.position, explosionRadius);
    }
}