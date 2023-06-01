using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int additionalBulletPower = 0;
    [SerializeField] private int additionalBulletHealth = 0;
    [SerializeField] private float minDelay = 0.8f;
    [SerializeField] private float maxDelay = 4f;
    
    private bool canShoot = true;

    private Rigidbody2D enemyRb;
    private GameObject bullet;
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

    private void Fire()
    {
        bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.GetComponent<EnemyBullet>().ModifyBullet(additionalBulletPower, additionalBulletHealth);
        enemyRb = bullet.GetComponent<Rigidbody2D>();
        enemyRb.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }
}