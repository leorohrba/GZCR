using UnityEngine;

public class MechaController : MonoBehaviour
{
    public float moveSpeed = 15f;
    public float rotationSpeed = 250f;
    private Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Handle movement and rotation directly with keys
        float moveInput = 0f;
        float rotationInput = 0f;

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

        // Apply movement (forward/backward)
        Vector2 forward = transform.up * moveInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + forward);

        if (Input.GetKeyUp(KeyCode.W) ||
            Input.GetKeyUp(KeyCode.S) || 
            Input.GetKeyUp(KeyCode.A) || 
            Input.GetKeyUp(KeyCode.D) ||
            Input.GetKeyUp(KeyCode.UpArrow) || 
            Input.GetKeyUp(KeyCode.DownArrow)) 
        {
            animator.SetBool("IsWalking", false);
        }
        // Apply rotation
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotation);
    }
}
