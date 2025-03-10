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
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }

        healthBar.fillAmount = health / maxHealth;
    }
    
    public void RegenHealth()
    {
        health += healthRegen;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        
        healthBar.fillAmount = health / maxHealth;
    }

    public void Die()
    {
        Debug.Log("Dead");
    }
}