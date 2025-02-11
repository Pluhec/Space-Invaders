using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform nozzle;
    public float bulletSpeed = 20f;
    public float specialAbilitySpeed = 40f;
    public int specialAbilityCount = 3;
    public float specialAbilityCooldown = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ShootSpecialAbility();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * bulletSpeed;
    }

    void ShootSpecialAbility()
    {
        float angleStep = 120f / (specialAbilityCount - 1);
        float startAngle = -60f;

        for (int i = 0; i < specialAbilityCount; i++)
        {
            float angle = startAngle + i * angleStep;
            float angleRad = angle * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Sin(angleRad), Mathf.Cos(angleRad));

            GameObject bullet = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * specialAbilitySpeed;
        }
    }
}