using UnityEngine;

public class TurretShot : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector
    public Transform firePoint;        // The position where the projectile spawns
    public float projectileSpeed = 10f; // Speed of the projectile
    public float animationDuration = 0.5f; // Duration of the shooting animation
    private float nextFireTime = 0f;    // Tracks when the cannon can fire again
    private float fireRate = 1f / 5f;   // Fire rate of 3 shots per second (1/3)
    private Animator animator;
    private bool isShooting = false;    // Tracks if the cannon is currently shooting

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for Spacebar input and if enough time has passed
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            Shoot();
        }
        else if (Input.GetKeyUp(KeyCode.Space)) // Stop the animation when spacebar is released
        {
            isShooting = false; // Reset shooting flag
            animator.SetBool("IsShooting", false);
        }
    }

    void Shoot()
    {
        // Trigger the shooting animation
        animator.SetBool("IsShooting", true);

        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));

        // Get the Rigidbody2D of the projectile and set its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * projectileSpeed; // Adjust direction based on the cannon's rotation

        // Set the next fire time to be after the specified fire rate
        nextFireTime = Time.time + fireRate;
    }
}
