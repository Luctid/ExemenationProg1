using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Default damage value, you can change it in the Unity Editor

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the bullet collides with an enemy
        if (other.CompareTag("Enemy"))
        {
            // Deal damage to the enemy
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Destroy the bullet upon collision
            Destroy(gameObject);
        }
    }
}
