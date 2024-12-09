using UnityEngine;

public class JetTurretsController : MonoBehaviour
{
    public float rotationSpeed = 150f; // Cannon rotation speed
    public float maxRotation = 30f;   // Maximum allowed rotation in degrees

    private float currentRotation = 0f; // Tracks the current rotation angle

    void Update()
    {
        // Combined input from keys and controller
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

        // Calculate rotation for this frame
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;

        // Update the current rotation angle and clamp it
        currentRotation = Mathf.Clamp(currentRotation + rotationAmount, -maxRotation, maxRotation);

        // Apply the clamped rotation to the turret
        transform.localRotation = Quaternion.Euler(0f, 0f, currentRotation);
    }
}
