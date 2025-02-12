using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public GameObject[] asteroidPrefabs;
    public GameObject EnemySpawn;
    public float asteroidSpeed = 5f;
    public float asteroidSpawnRate = 1f;

    private BoxCollider2D spawnArea;

    void Start()
    {
        spawnArea = EnemySpawn.GetComponent<BoxCollider2D>();
        InvokeRepeating("SpawnAsteroid", 0, asteroidSpawnRate);
    }

    public void SpawnAsteroid()
    {
        int randomIndex = Random.Range(0, asteroidPrefabs.Length);
        Vector2 spawnPosition = GetRandomPositionInCollider();
        GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], spawnPosition, Quaternion.identity);
        Rigidbody2D rb = asteroid.GetComponent<Rigidbody2D>();
        
        float angle = Random.Range(-45f, 45f);
        Vector2 direction = Quaternion.Euler(0, 0, angle) * Vector2.down;

        rb.linearVelocity = direction * asteroidSpeed;
    }

    private Vector2 GetRandomPositionInCollider()
    {
        Bounds bounds = spawnArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);
        return new Vector2(x, y);
    }
}