using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 5f; // Time the bullet will live
    public int bulletDamage = 10; // Amount of damage to apply

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Check if the shooting point and bullet prefab are set
        if (shootingPoint != null && bulletPrefab != null)
        {
            // Instantiate a new bullet at the shooting point position and rotation
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);

            // Get the Rigidbody2D component of the bullet
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

            // Check if the bullet has a Rigidbody2D component
            if (bulletRb != null)
            {
                // Apply force to the bullet in the positive X direction
                bulletRb.velocity = new Vector2(bulletSpeed, 0f);

                // Destroy the bullet after a specified lifetime
                Destroy(bullet, bulletLifetime);
            }
            else
            {
                Debug.LogError("Bullet prefab is missing Rigidbody2D component.");
            }
        }
        else
        {
            Debug.LogError("Shooting point or bullet prefab is not set.");
        }
    }

    // This method is called when a collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Enemy" tag
        if (other.CompareTag("Enemy"))
        {
            // Retrieve the EnemyHealth component from the collided object
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            // Check if the enemy has a health component
            if (enemyHealth != null)
            {
                // Apply damage to the enemy
                enemyHealth.TakeDamage(bulletDamage);

                // Destroy the bullet upon hitting the enemy
                Destroy(gameObject);
            }
        }
    }
}
