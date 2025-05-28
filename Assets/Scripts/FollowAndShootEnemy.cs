using UnityEngine;

public class FollowAndShootEnemy : MonoBehaviour
{
    [Header("References")]
    public Transform player;
    public Transform nozzle;
    public GameObject bulletPrefab;

    [Header("Movement")]
    public float speed = 3f;
    public float stoppingDistance = 5f;
    public float chaseBuffer = 1f;

    [Header("Shooting")]
    public float minShootInterval = 1f;
    public float maxShootInterval = 2f;
    public float bulletSpeed = 10f;

    private float shootTimer;

    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player").transform;

        shootTimer = GetRandomShootInterval();
    }

    void Update()
    {
        Vector2 dirToPlayer = (player.position - transform.position).normalized;
        
        float angle = Mathf.Atan2(dirToPlayer.y, dirToPlayer.x) * Mathf.Rad2Deg - 90f + 180f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        // vzdalenost
        float dist = Vector2.Distance(transform.position, player.position);

        if (dist > stoppingDistance + chaseBuffer)
        {
            // chase
            transform.position += (Vector3)(dirToPlayer * speed * Time.deltaTime);
        }
        else if (dist > stoppingDistance)
        {
            // bo se cukal jak kokot
        }
        else
        {
            shootTimer -= Time.deltaTime;
            if (shootTimer <= 0f)
            {
                ShootAtPlayer();
                shootTimer = GetRandomShootInterval();
            }
        }
    }

    private void ShootAtPlayer()
    {
        Vector2 shootDir = (player.position - nozzle.position).normalized;
        GameObject proj = Instantiate(bulletPrefab, nozzle.position, Quaternion.identity);
        Rigidbody2D rb = proj.GetComponent<Rigidbody2D>();
        rb.linearVelocity = shootDir * bulletSpeed;
    }

    private float GetRandomShootInterval()
    {
        return Random.Range(minShootInterval, maxShootInterval);
    }
}