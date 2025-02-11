using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform nozzle; // Position from where the bullets will be fired
    public float bulletSpeed = 20f; // Speed of the bullet
    public float fireRate = 0.5f; // Rate of fire

    private float nextFireTime = 0f;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = nozzle.right * bulletSpeed;
    }
}