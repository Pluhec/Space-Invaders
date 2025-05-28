using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Settings")]
    public float asteroidDamage = 50f;
    public int scoreValue = 2;

    private void Start()
    {
        Destroy(gameObject, 7f);
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("bullet"))
        {
            Destroy(col.gameObject);
            AddScoreToPlayer();
            Destroy(gameObject);
        }
        else if (col.CompareTag("asteroidDeleteBarrier"))
        {
            Destroy(gameObject);
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var healthComp = collision.gameObject.GetComponent<Health>();
            if (healthComp != null)
                healthComp.TakeDamage(asteroidDamage);

            Destroy(gameObject);
        }
    }

    private void AddScoreToPlayer()
    {
        var player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            var scoreComp = player.GetComponent<ScoreManager>();
            if (scoreComp != null)
                scoreComp.AddScore(scoreValue);
        }
    }
}