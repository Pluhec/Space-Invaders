using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public GameObject bullet;
    public float asteroidDamage = 50;

    private void Start()
    {
        Destroy(gameObject, 7f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "asteroidDeleteBarrier":
                Destroy(gameObject);
                break;
            case "Player":
                Destroy(gameObject);
                var healthComponent = collision.gameObject.GetComponent<Health>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(asteroidDamage);
                    Debug.Log("posilam dmg na hrace");
                }
                break;
            case "bullet":
                Destroy(gameObject);
                Debug.Log("Collided with bullet");
                break;
        }
    }
}