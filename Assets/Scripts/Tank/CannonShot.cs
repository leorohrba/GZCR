using UnityEngine;

public class CannonShot : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector
    public Transform firePoint;        // The position where the projectile spawns
    public float projectileSpeed = 10f; // Speed of the projectile
    public float animationDuration = 0.5f; // Duration of the shooting animation
    private float nextFireTime = 0.6f;    // Tracks when the cannon can fire again
    private Animator animator;
    private bool isShooting = false;    // Tracks if the cannon is currently shooting

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // Check for Spacebar input
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextFireTime)
        {
            // If the cannon is not already shooting, start the shooting animation
            if (!this.animator.GetCurrentAnimatorStateInfo(0).IsName("CannonShot"))
            {
                Shoot();
            }

        }
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");
        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));

        // Get the Rigidbody2D of the projectile and set its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * projectileSpeed; // Adjust direction based on the cannon's rotation
        nextFireTime = Time.time + animationDuration;
    }
}
