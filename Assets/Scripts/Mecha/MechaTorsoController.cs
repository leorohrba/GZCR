using UnityEngine;

public class MechaTorsoController : MonoBehaviour
{
    public float rotationSpeed = 250f; // Cannon rotation speed

    void FixedUpdate()
    {
        float rotationInput = 0f;

        // Keyboard inputs
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationInput = 1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationInput = -1f;
        }

        // Controller input (right stick horizontal axis)
        rotationInput += Input.GetAxis("JoystickCannonHorizontal"); // Replace with correct joystick axis

        // Apply rotation to the child
        float rotationAmount = rotationInput * rotationSpeed * Time.fixedDeltaTime;
        transform.Rotate(0, 0, rotationAmount);

        // Physics-based position sync
        if (transform.parent != null)
        {
            Rigidbody2D parentRb = transform.parent.GetComponent<Rigidbody2D>();
            if (parentRb != null)
            {
                transform.position = parentRb.position; // Smoothly sync with parent's position
            }
        }
    }
}
