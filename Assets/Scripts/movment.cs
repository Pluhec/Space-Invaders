using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D body;

    [SerializeField] private Animator _animator;
    public GameObject flameR;
    public GameObject flameL;

    public float moveSpeed = 2.0f;
    public float rotationSpeed = 200.0f;

    private float moveInput;
    private float rotationInput;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        rotationInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        moveInput = Mathf.Clamp(moveInput, 0, 1);
        
        float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        body.rotation -= rotation;
        
        Vector2 direction = transform.up;
        body.linearVelocity = direction * moveInput * moveSpeed;

        if (moveInput != 0)
        {
            _animator.SetBool("isMoving", true);
            flameL.SetActive(true);
            flameR.SetActive(true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
            flameL.SetActive(false);
            flameR.SetActive(false);
        }
    }
}