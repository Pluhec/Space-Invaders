using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class ShieldController : MonoBehaviour
{
    [Header("Shield Settings")]
    public float shieldDuration = 5f;

    [Header("Icon")]
    public SpriteRenderer shieldIconRenderer;

    [Header("Opacita")]
    [Range(0f, 1f)] public float inactiveAlpha = 0f;
    [Range(0f, 1f)] public float activeAlpha = 1f;

    bool isShielded;

    void Start()
    {
        if (shieldIconRenderer != null)
        {
            var c = shieldIconRenderer.color;
            shieldIconRenderer.color = new Color(c.r, c.g, c.b, inactiveAlpha);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            ActivateShield();
    }

    public void ActivateShield()
    {
        if (isShielded) return;
        StartCoroutine(ShieldRoutine());
    }

    IEnumerator ShieldRoutine()
    {
        isShielded = true;
        
        if (shieldIconRenderer != null)
        {
            var c = shieldIconRenderer.color;
            shieldIconRenderer.color = new Color(c.r, c.g, c.b, activeAlpha);
        }
        
        yield return new WaitForSeconds(shieldDuration);
        
        if (shieldIconRenderer != null)
        {
            var c = shieldIconRenderer.color;
            shieldIconRenderer.color = new Color(c.r, c.g, c.b, inactiveAlpha);
        }

        isShielded = false;
    }

    public bool IsShielded() => isShielded;
}