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
        float dist = Vector2.Distance(transform.position, player.position);

        if (dist > stoppingDistance + chaseBuffer)
        {
            Vector2 dir = (player.position - transform.position).normalized;
            transform.position += (Vector3)(dir * speed * Time.deltaTime);
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