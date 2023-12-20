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

                // Attach damage information directly to the bullet
                bullet.GetComponent<Bullet>().damage = bulletDamage;

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
}
