using UnityEngine;

public class Health : MonoBehaviour
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

        // Additional logic for handling damage, e.g., checking if the player is still alive

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Additional logic for player death, e.g., game over or respawn
        Debug.Log("Player has died!");
    }
}
