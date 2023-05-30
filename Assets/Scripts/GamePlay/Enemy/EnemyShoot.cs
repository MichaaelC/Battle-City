using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float minDelay = 0.8f;
    public float maxDelay = 4f;
    public bool canShoot = true;

    private WaitForSeconds wait;

    private void Awake()
    {
        wait = new(Random.Range(minDelay, maxDelay));
    }

    private void Start()
    {
        StartCoroutine(ShootDelay());
    }

    private IEnumerator ShootDelay()
    {
        while (canShoot)
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
