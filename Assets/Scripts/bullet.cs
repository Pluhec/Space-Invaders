using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bulletDeleteBarrier"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("asteroid"))
        {
            Destroy(gameObject);
        }
    }
}