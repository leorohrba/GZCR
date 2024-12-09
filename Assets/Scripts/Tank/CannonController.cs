using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 150f; // Cannon rotation speed

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

        // Apply rotation
        float rotationAmount = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotationAmount);
    }
}
