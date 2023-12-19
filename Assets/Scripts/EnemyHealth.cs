// Example EnemyHealth script
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy has no health remaining
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Handle death logic, such as playing death animation or destroying the enemy GameObject
        Destroy(gameObject);
    }
}
