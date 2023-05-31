using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefabs;
    [SerializeField] private float fireRate = 0.8f;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private int additionalBulletPower = 0;
    [SerializeField] private int additionalBulletHealth = 0;
    [SerializeField] private bool isReadyToFire = true;

    private GameObject bullet;
    private WaitForSeconds wait;

    private void Start()
    {
        wait = new(fireRate);
    }

    public void Shoot(Direction dir)
    {
        if (isReadyToFire)
        {
            bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
            bullet.GetComponent<PlayerBullet>().ModifyBullet(additionalBulletPower, additionalBulletHealth);

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

    public void ModifyShootProperties(float fireRateValue, float bulletSpeedValue, int bulletPowerValue, int bulletHealthValue)
    {
        this.fireRate *= fireRateValue;
        this.bulletSpeed *= bulletSpeedValue;
        this.additionalBulletHealth += bulletHealthValue;
        this.additionalBulletPower += bulletPowerValue;
    }
}