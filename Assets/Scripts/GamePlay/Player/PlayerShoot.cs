using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float fireRate = 0.8f;
    public float bulletSpeed = 5f;
    public bool isReadyToFire = true;

    private WaitForSeconds wait;

    private void Start()
    {
        wait = new(fireRate);
    }

    public void Shoot(Direction dir)
    {
        if (isReadyToFire)
        {
            var bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);

            switch (dir)
            {
                case Direction.up:
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
                    break;
                case Direction.down:
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
                    break;
                case Direction.left:
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
                    break;
                case Direction.right:
                    bullet.GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
                    break;
            }

            isReadyToFire = false;
            StartCoroutine(ShootCooldown());
        }
    }

    private IEnumerator ShootCooldown()
    {
        yield return wait;
        isReadyToFire = true;
        yield break;
    }
}