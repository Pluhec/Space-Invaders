using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    public float health = 10f;
    public float maxHealth = 10f;
    public float healthRegen = 0.1f;

    public GameObject deathScreen;
    
    public void TakeDamage(float damage)
    {
        var shield = GetComponent<ShieldController>();
        if (shield != null && shield.IsShielded())
            return;

        health -= damage;
        if (health <= 0)
            Die();

        healthBar.fillAmount = health / maxHealth;
    }

    public void Die()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void playExplosion()
    {
        
    }
}