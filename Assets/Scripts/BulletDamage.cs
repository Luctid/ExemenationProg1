using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    private int damage;

    // Set the damage value for the bullet
    public void SetDamage(int bulletDamage)
    {
        damage = bulletDamage;
    }

    // This method is called when a collider enters the trigger collider attached to this GameObject
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
