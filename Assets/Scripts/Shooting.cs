using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform nozzle;
    public float bulletSpeed = 20f;
    public float specialAbilitySpeed = 40f;
    public int specialAbilityCount = 8;
    public float specialAbilityCooldown = 10f;

    public AudioClip laserClip;
    
    private float cooldownTimer = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if (Input.GetMouseButtonDown(1) && cooldownTimer <= 0f)
        {
            ShootSpecialAbility();
            cooldownTimer = specialAbilityCooldown;
        }

        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.up * bulletSpeed;
        
        AudioManager.Instance.PlaySFX(laserClip);
    }

    void ShootSpecialAbility()
    {
        float angleStep = 360f / specialAbilityCount;
        float startAngle = 0f;

        for (int i = 0; i < specialAbilityCount; i++)
        {
            float angle = startAngle + i * angleStep;
            float angleRad = (angle + transform.eulerAngles.z) * Mathf.Deg2Rad;
            Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

            GameObject bullet = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * specialAbilitySpeed;
        }
    }
}