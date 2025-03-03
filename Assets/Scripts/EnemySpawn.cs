using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    
    public GameObject enemyPrefab;
    public BoxCollider2D spawnEnemy;
    public float enemySpeed = 1f;
    public float enemySpawnRate = 1f;

    void Start()
    {
        spawnEnemy = spawnEnemy.GetComponent<BoxCollider2D>();
        InvokeRepeating("SpawnAsteroid", 0, enemySpawnRate);
    }

    public void SpawnAsteroid()
    {
        Vector2 spawnPosition = GetRandomYPositionInCollider();
        enemyPrefab = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = enemyPrefab.GetComponent<Rigidbody2D>();
        
        Vector2 direction = Quaternion.Euler(0, 0, 0) * Vector2.down;

        rb.linearVelocity = direction * enemySpeed;
    }
    
    private Vector2 GetRandomYPositionInCollider()
    {
        Bounds bounds = spawnEnemy.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = bounds.max.x;
        return new Vector2(x, y);
    }
}
