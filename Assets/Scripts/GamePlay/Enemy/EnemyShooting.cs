using System.Collections;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float minDelay = 1f;
    public float maxDelay = 4f;

    private WaitForSeconds wait;

    void Start()
    {
        wait = new(Random.Range(minDelay, maxDelay));
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        while (true)
        {
            Fire();
            wait = new(Random.Range(minDelay, maxDelay));
            yield return wait;
        }
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}
