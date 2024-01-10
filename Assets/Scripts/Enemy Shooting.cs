using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; // Serialized field to allow drag-and-drop in the Inspector

    public Transform bulletSpawnPoint;
    public float shootInterval = 1f; // Time between shots
    private float timeSinceLastShot = 0f;

    void Update()
    {
        if (!IsInWave())
        {
            ShootRandomly();
        }
    }

    void ShootRandomly()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootInterval)
        {
            if (bulletPrefab != null) // Check if bulletPrefab is assigned
            {
                Shoot();
                timeSinceLastShot = 0f; // Reset the timer
            }
            else
            {
                Debug.LogError("Bullet Prefab not assigned to EnemyShooting script.");
            }
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Get the Rigidbody2D component of the bullet
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Check if the Rigidbody2D component exists
        if (bulletRb != null)
        {
            // Set the initial velocity of the bullet to move to the left
            float bulletSpeed = 10f; // Adjust the speed as needed
            bulletRb.velocity = new Vector2(-bulletSpeed, 0f); // Set velocity to move left
        }
        else
        {
            Debug.LogError("Rigidbody2D not found on the bullet prefab.");
        }
    }

    bool IsInWave()
    {
        // Implement your logic to determine if the enemy is in a wave
        // Check if this enemy was spawned during a wave or not
        // Return true if in a wave, false otherwise

        // For example, if enemies during waves have a specific tag, you can do something like:
        // return gameObject.CompareTag("EnemyInWave");

        return false;
    }

    // Method to set the bullet prefab
    public void SetBulletPrefab(GameObject newBulletPrefab)
    {
        bulletPrefab = newBulletPrefab;
    }
}
