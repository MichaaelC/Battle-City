using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefabs;
    public float bulletSpeed = 10f;
    

    public void Shoot(Direction dir)
    {
        var b = Instantiate(bulletPrefabs, transform.position, transform.rotation);
        switch (dir)
        {
            case Direction.up:
                b.GetComponent<Rigidbody2D>().velocity = Vector2.up * 2f;
                break;
            case Direction.down:
                b.GetComponent<Rigidbody2D>().velocity = Vector2.down * 2f;
                break;
            case Direction.left:
                b.GetComponent<Rigidbody2D>().velocity = Vector2.left * 2f;
                break;
            case Direction.right:
                b.GetComponent<Rigidbody2D>().velocity = Vector2.right * 2f;
                break;
        }
    }
}
