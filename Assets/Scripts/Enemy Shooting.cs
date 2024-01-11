using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;

    public Transform bulletSpawnPoint;
    public float shootInterval = 1f;
    private float timeSinceLastShot = 0f;
    public float moveSpeed = 2f; // Adjust the move speed as needed

    void Update()
    {
        if (!IsInWave())
        {
            MoveLeft();
            ShootRandomly();
        }
    }

    void MoveLeft()
    {
        // Move the object to the left based on its current position and speed
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void ShootRandomly()
    {
        timeSinceLastShot += Time.deltaTime;

        if (timeSinceLastShot >= shootInterval)
        {
            if (bulletPrefab != null)
            {
                Shoot();
                timeSinceLastShot = 0f;
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
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        if (bulletRb != null)
        {
            float bulletSpeed = 10f;
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
