using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bulletDeleteBarrier")
        { 
            Debug.Log("kokotina to je");
        }
    }
}