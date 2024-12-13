using UnityEngine;

public class CannonShot : MonoBehaviour
{
    public GameObject projectilePrefab; // Assign the projectile prefab in the Inspector
    public Transform firePoint;         // The position where the projectile spawns
    public float projectileSpeed = 10f; // Speed of the projectile
    public float animationDuration = 0.5f; // Duration of the shooting animation
    private float nextFireTime = 0f;  // Tracks when the cannon can fire again
    private Animator animator;

    public Transform parentTransform;
    private bool isShooting = false;    // Tracks if the cannon is currently shooting
    public float recoilForce = 380f;     // Force to apply for recoil
    public float brakeForce = 100f;     // Force to apply for recoil
    public float recoilDelay = 0.2f;     // Force to apply for recoil
    public float backRecoilDelay = 0.4f;     // Force to apply for recoil

    private TankBaseController tankController;

    void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        if (parentTransform == null)
        {
            parentTransform = transform.parent;
        }

        // Ensure the TankBaseController is not null
        tankController = GetComponentInParent<TankBaseController>();
        if (tankController == null)
        {
            Debug.LogError("TankBaseController is not assigned to the tankController variable.");
        }
    }

    void Update()
    {
        // Check for Spacebar input
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
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

        // Apply recoil to the tank
        Vector2 recoilDirection = -firePoint.up; // Opposite direction of the shot
        Vector2 brakeDirection = firePoint.up; // Opposite direction of the shot

        // Apply recoil force 0.3 seconds after the shot
        tankController.AddForceWithDelay(recoilDirection * recoilForce, recoilDelay);

        // Apply brake force 0.4 seconds after the initial recoil
        tankController.AddForceWithDelay(brakeDirection * brakeForce, backRecoilDelay);
    }
    
}