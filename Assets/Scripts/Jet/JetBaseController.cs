using UnityEngine;

public class JetBaseController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float rotationSpeed = 200f;
    public float maxSpeed = 35f;
    public float maxAngularSpeed = 100f;
    public float acceleration = 18f; // Acceleration rate
    public float deceleration = 36f; // Deceleration rate (higher than acceleration)
    public float damping = 0.9f; // Damping factor to reduce velocity gradually

    private Rigidbody2D rb;
    private Animator animator;
    private float moveInput;
    private float rotationInput;
    private float currentSpeed = 0f; // Current speed of the mecha

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        moveInput = 0f;
        rotationInput = 0f;

        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow))) // Move forward
        {
            moveInput = 1f;
        }
        else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow))) // Move backward
        {
            moveInput = -1f; // Use -1 for reversing
        }

        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            rotationInput = 1f;
        }
        else if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            rotationInput = -1f;
        }

        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S) || 
            Input.GetKeyUp(KeyCode.A) || 
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.UpArrow) || 
            Input.GetKeyUp(KeyCode.DownArrow))
        {
            // animator.SetBool("IsWalking", false);
        }
    }

    void FixedUpdate()
    {
        // Gradually increase or decrease the current speed based on moveInput
        float targetSpeed = moveInput * moveSpeed;
        float rate = moveInput == 0 ? deceleration : acceleration;
        currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, rate * Time.fixedDeltaTime);

        // Apply damping to reduce velocity gradually
        if (moveInput == 0)
        {
            currentSpeed *= damping;
        }

        // Calculate the desired velocity
        Vector2 forward = transform.up * currentSpeed;
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