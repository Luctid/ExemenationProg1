using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        // Reduce health by the damage amount
        currentHealth =- damageAmount;

        // Check if the enemy should be destroyed
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
