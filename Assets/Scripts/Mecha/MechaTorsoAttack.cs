using UnityEngine;
using System.Collections;

public class MechaTorsoAttack : MonoBehaviour
{
    public GameObject swingProjectilePrefab; // Assign the projectile prefab in the Inspector
    public Transform swingFirePoint;         // The position where the projectile spawns
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector
    public Transform firePoint;        // The position where the projectile spawns
    public float projectileSpeed = 10f; // Speed of the projectile
    public float animationDuration = 0.5f; // Duration of the shooting animation
    private float nextFireTime = 0f;    // Tracks when the cannon can fire again
    private float fireRate = 0.5f;   // Fire rate of 3 shots per second (1/3)
    private Animator animator;
    private bool isShooting = false;    // Tracks if the cannon is currently shooting
    private bool isSwinging = false;   // Tracks if the mech is performing a swing attack

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Handle shooting attack with Spacebar
        if (Input.GetKey(KeyCode.Space) &&
            Time.time >= nextFireTime &&
            isShooting == false &&
            isSwinging == false)
        {
            Shoot();
        }
        // Handle swing attack with Enter key
        else if (!Input.GetKey(KeyCode.Space) &&
                 !isSwinging &&
                 Input.GetKeyDown(KeyCode.Return) &&
                 isShooting == false)
        {
            SwingAttack();
        }
        if (Input.GetKeyUp(KeyCode.Space)) // Stop the shooting animation when Spacebar is released
        {
            isShooting = false; // Reset shooting flag
            animator.SetBool("IsShooting", false);
        }

    }

    void Shoot()
    {
        isShooting = true; // Reset shooting flag

        // Start a coroutine to delay the projectile instantiation
        StartCoroutine(DelayedProjectileInstantiation());
    }

    IEnumerator DelayedProjectileInstantiation()
    {
        animator.SetBool("IsShooting", true);
        // Wait for 50 milliseconds (0.05 seconds)
        yield return new WaitForSeconds(0.05f);

        // Instantiate the projectile at the fire point
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation * Quaternion.Euler(0, 0, 90));

        // Get the Rigidbody2D of the projectile and set its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * projectileSpeed; // Adjust direction based on the cannon's rotation
        nextFireTime = Time.time + animationDuration + fireRate;

        Invoke(nameof(ResetShot), animationDuration);
    }

    void SwingAttack()
    {
        isSwinging = true;
        animator.SetTrigger("Swing"); // Assuming you have a "SwingAttack" trigger in the Animator

        GameObject projectile = Instantiate(swingProjectilePrefab, swingFirePoint.position, swingFirePoint.rotation);

        // Get the Rigidbody2D of the projectile and set its velocity
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.up * projectileSpeed; // Adjust direction based on the cannon's rotation
        nextFireTime = Time.time + animationDuration;


        // Add a small delay before allowing another swing
        Invoke(nameof(ResetSwing), animationDuration);
    }

    void ResetSwing()
    {
        isSwinging = false;
    }
    void ResetShot()
    {
        isShooting = false;
        animator.SetBool("IsShooting", false);
    }
}
