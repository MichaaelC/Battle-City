using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float bulletSpeed = 10f;

    public void Shoot(Direction dir)
    {
        var bullet = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        
        switch (dir)
        {
            case Direction.up:
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
                break;
            case Direction.down:
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.down * bulletSpeed;
                break;
            case Direction.left:
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.left * bulletSpeed;
                break;
            case Direction.right:
                bullet.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;
                break;
        }

    }
}