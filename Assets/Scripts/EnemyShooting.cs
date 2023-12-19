using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public float bulletSpeed = 10f;
    public float shootingInterval = 2f; // Time between shots
    private float timeSinceLastShot;

    void Update()
    {
        // Increment the timer
        timeSinceLastShot += Time.deltaTime;

        // Check if enough time has passed to shoot again
        if (timeSinceLastShot >= shootingInterval)
        {
            Shoot();
            timeSinceLastShot = 0f; // Reset the timer
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
                // Apply force to the bullet in the negative X direction (opposite of player's bullets)
                bulletRb.velocity = new Vector2(-bulletSpeed, 0f);
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
}
