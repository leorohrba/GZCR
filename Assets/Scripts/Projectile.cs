using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifetime = 5f; // Time before the projectile is destroyed

    void Start()
    {
        // Destroy the projectile after a set time
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Ignore collisions with any object tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            Collider2D projectileCollider = GetComponent<Collider2D>();
            Collider2D playerCollider = collision.collider;

            // Ignore future collisions between projectile and player
            if (projectileCollider != null && playerCollider != null)
            {
                Physics2D.IgnoreCollision(projectileCollider, playerCollider);
            }

            return; // Do nothing else for this collision
        }

        // Destroy the object if it's not a wall
        if (!collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject);
        }

        // Destroy the projectile on impact
        Destroy(gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Prevent the projectile from applying forces to the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                playerRb.linearVelocity = Vector2.zero; // Remove any applied velocity
            }
        }
    }
}
