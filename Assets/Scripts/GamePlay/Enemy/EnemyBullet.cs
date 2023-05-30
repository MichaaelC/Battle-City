using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float timer = 5f;
    [SerializeField] private int health = 1;
    [SerializeField] private int damage = 1;
    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private Vector2 explosionRadius = new Vector2(1f, 1f);
    private List<Collider2D> explosionHits;

    private void Start()
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
            else if (item.GetComponent<HealthPlayer>())
            {
                item.GetComponent<HealthPlayer>().GetDamage(damage);
                Hit();
            }
            else if (item.GetComponent<PlayerBullet>())
            {
                item.GetComponent<PlayerBullet>().Hit();
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
        Instantiate(explosionPrefab, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, explosionRadius);
    }
}