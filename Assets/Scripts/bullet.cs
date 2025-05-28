using UnityEngine;

public class bullet : MonoBehaviour
{
    [Header("Nastavení poškození")]
    public float damage = 1f;
    public float lifetime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
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
            return;
        }
        
    }
}