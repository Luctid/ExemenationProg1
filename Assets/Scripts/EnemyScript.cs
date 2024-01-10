using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private GameManager gameManager; // Reference to the GameManager

    void Start()
    {
        // Find the GameManager in the scene and store a reference to it
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager not found in the scene!");
        }
    }

    void OnDestroy()
    {
        // Check if the gameManager reference is not null before calling EnemyDefeated
        if (gameManager != null)
        {
            // Call GameManager.EnemyDefeated() when the enemy is destroyed
            gameManager.EnemyDefeated();
        }
    }
}
