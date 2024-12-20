using UnityEngine;

public class MechaController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float maxSpeed = 10f;
    public float maxAngularSpeed = 100f;

    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = Input.GetAxis("Vertical"); // Forward/backward input
        rotationInput = 0f;

        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow))) // Move forward
        {
            animator.SetBool("IsWalking", true);

            moveInput = 1f;

        }
        else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow))) // Move backward
        {
            animator.SetBool("IsWalking", true);
            moveInput = -0.5f;
        }

        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            animator.SetBool("IsWalking", true);
            rotationInput = 1f;
        }
        else if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            animator.SetBool("IsWalking", true);
            rotationInput = -1f;
        }

        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S) || 
            Input.GetKeyUp(KeyCode.A) || 
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.UpArrow) || 
            Input.GetKeyUp(KeyCode.DownArrow)) 
        {
            animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate()
    {
        // Calculate the desired velocity
        Vector2 forward = transform.up * moveInput * moveSpeed;
        rb.linearVelocity = forward;

        // Apply rotation using MoveRotation
        float rotation = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation + rotation);

        // Clamp the linear velocity
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

        // Clamp the angular velocity
        if (Mathf.Abs(rb.angularVelocity) > maxAngularSpeed)
        {
            rb.angularVelocity = Mathf.Sign(rb.angularVelocity) * maxAngularSpeed;
        }
    }
        // Reset velocity on collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }
}