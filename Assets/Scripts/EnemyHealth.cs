using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 3f;
    private float currentHealth;

    [Header("Death & Score")]
    public GameObject explosionPrefab;
    public int scoreValue = 5;

    private void Start()
    {
        currentHealth = maxHealth;
    }
    
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
            Die();
    }

    private void Die()
    {
        if (explosionPrefab != null)
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            var score = player.GetComponent<ScoreManager>();
            if (score != null)
                score.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}