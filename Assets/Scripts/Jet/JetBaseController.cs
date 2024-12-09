using UnityEngine;

public class JetBaseController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 200f;

    private Rigidbody2D rb;

    void Start()
    {
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
            moveInput = 1f;
        }
        else if ((Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.DownArrow))) // Move backward
        {
            moveInput = -0.5f;
        }

        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            rotationInput = 1f;
        }
        else if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            rotationInput = -1f;
        }

        // Apply movement (forward/backward)
        Vector2 forward = transform.up * moveInput * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + forward);

        // Apply rotation
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(rb.rotation + rotation);
    }
}
