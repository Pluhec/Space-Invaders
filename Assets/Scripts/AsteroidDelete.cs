using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AsteroidDelete : MonoBehaviour
{
    public GameObject bullet;
    
    private void Start()
    {
        Destroy(gameObject, 7f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("asteroidDeleteBarrier"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("GameOver");
        }

        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Debug.Log("Colided with bullet");
        }
    }
}