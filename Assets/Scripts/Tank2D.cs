using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank2D : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefabs;
    public float bulletSpeed = 10f;
    public float moveSpeed = 2f;
    public float bulletDelay = 1f;

    void Update()
    {
        Movement();
        Shooting();
    }

    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (h != 0)
        {
            transform.position += new Vector3(h * moveSpeed * Time.deltaTime, 0, 0);
            transform.rotation = Quaternion.Euler(0, 0, -90 * h);
        }
        else if(v != 0)
        {
            transform.position += new Vector3(0, v * moveSpeed * Time.deltaTime, 0);
            transform.rotation = Quaternion.Euler(0, 0, 90 - 90 * v);
        }
    }
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var bullet = Instantiate(bulletPrefabs, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.up * bulletSpeed;
        }
    }
}
