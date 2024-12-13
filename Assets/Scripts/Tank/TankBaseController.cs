using UnityEngine;
using System.Collections;

public class TankBaseController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public float maxSpeed = 10f;
    public float maxAngularSpeed = 100f;

    private Rigidbody2D rb;
    private float moveInput;
    private float rotationInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveInput = Input.GetAxis("Vertical"); // Forward/backward input
        rotationInput = 0f;

        if (Input.GetKey(KeyCode.A)) // Rotate left
        {
            rotationInput = 1f;
        }
        else if (Input.GetKey(KeyCode.D)) // Rotate right
        {
            rotationInput = -1f;
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

    public void AddForce(Vector2 force)
    {
        rb.AddForce(force);
    }

    public void AddForceWithDelay(Vector2 force, float delay)
    {
        StartCoroutine(AddForceAfterDelay(force, delay));
    }

    private IEnumerator AddForceAfterDelay(Vector2 force, float delay)
    {
        yield return new WaitForSeconds(delay);
        AddForce(force);
    }
    // public void ApplyRecoil(Vector2 recoilForce)
    // {
    //     rb.AddForce(recoilForce);
    // }

}