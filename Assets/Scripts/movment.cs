using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;
    
    [SerializeField] private Animator _animator;
    public GameObject flameR;
    public GameObject flameL;

    float horizontal;
    float vertical;

    public float runSpeed = 2.0f;
    public float health = 1f;

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
        body.linearVelocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        if (horizontal != 0)
        {
            _animator.SetBool("isRight", horizontal > 0);
            if (_animator.GetBool("isRight"))
            {
                flameL.transform.localScale = new Vector3(0.3f, 0.3f, 0);
                flameL.transform.rotation = Quaternion.Euler(0, 0, -30);
                flameR.transform.localScale = new Vector3(0.4377788f, 0.4377788f, 0);
                flameR.transform.rotation = Quaternion.Euler(0, 0, -30);

            }
            _animator.SetBool("isLeft", horizontal < 0);
            if (_animator.GetBool("isLeft"))
            {
                
                flameL.transform.rotation = Quaternion.Euler(0, 0, 30);
                flameR.transform.localScale = new Vector3(0.3f, 0.3f, 0);
                flameR.transform.rotation = Quaternion.Euler(0, 0, 30);
                flameL.transform.localScale = new Vector3(0.4377788f, 0.4377788f, 0);
            }
        }
        else
        {
            _animator.SetBool("isRight", false);
            _animator.SetBool("isLeft", false);
            flameL.transform.rotation = Quaternion.Euler(0, 0, 0);
            flameR.transform.rotation = Quaternion.Euler(0, 0, 0);
            flameL.transform.localScale = new Vector3(0.4377788f, 0.4377788f, 0);
            flameR.transform.localScale = new Vector3(0.4377788f, 0.4377788f, 0);
        }
        
    }
}