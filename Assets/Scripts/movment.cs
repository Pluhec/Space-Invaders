using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    
    [SerializeField] private Animator _animator;

    float horizontal;
    float vertical;

    public float runSpeed = 2.0f;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {  
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (horizontal != 0)
        {
            _animator.SetBool("isRight", horizontal > 0);
            _animator.SetBool("isLeft", horizontal < 0);
        }
        else
        {
            _animator.SetBool("isRight", false);
            _animator.SetBool("isLeft", false);
        }
        
    }
}