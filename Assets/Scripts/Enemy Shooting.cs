using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float shootInterval = 1f; // Time between shots
    private float timeSinceLastShot = 0f;

    void Update()
    {
        ShootRandomly();
    }

    void ShootRandomly()
    {
        // Update the timer
        timeSinceLastShot += Time.deltaTime;

        // Check if it's time to shoot
        if (timeSinceLastShot >= shootInterval)
        {
            Shoot();
            timeSinceLastShot = 0f; // Reset the timer
        }
    }

    void Shoot()
    {
        // Instantiate a bullet at the specified spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Detach the bullet from the enemy
        bullet.transform.parent = null;

        // Add a Rigidbody2D component to the bullet, if not already present
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        if (bulletRb == null)
        {
            bulletRb = bullet.AddComponent<Rigidbody2D>();
        }

        // Set the gravity scale to 0 to make the bullet unaffected by gravity
        bulletRb.gravityScale = 0f;

        // Set the initial velocity of the bullet to move to the left
        float bulletSpeed = 10f; // Adjust the speed as needed
        bulletRb.velocity = new Vector2(-bulletSpeed, 0f); // Adjust the direction as needed

        // Set the rotation of the bullet to ensure it faces the correct direction
        bullet.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        // Destroy the bullet after 5 seconds (adjust the time as needed)
        Destroy(bullet, 5f);
    }




}
