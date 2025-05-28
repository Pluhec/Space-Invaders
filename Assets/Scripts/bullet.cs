using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class bullet : MonoBehaviour
{
    [Header("Dmg settings")]
    public float damage = 1f;
    public float lifetime = 2f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, lifetime);
        
        AlignRotationWithVelocity();
    }

    private void AlignRotationWithVelocity()
    {
        Vector2 v = rb.velocity;
        if (v.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bulletDeleteBarrier"))
        {
            Destroy(gameObject);
            return;
        }
        if (collision.CompareTag("asteroid"))
        {
            Destroy(gameObject);
            return;
        }
        var healthComp = collision.GetComponent<Health>();
        if (healthComp != null)
        {
            healthComp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}