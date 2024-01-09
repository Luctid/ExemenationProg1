using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        UpdateUI();
    }

    public void TakeDamage(int damage)
    {
        currentLives -= damage;

        if (currentLives <= 0)
        {
            currentLives = 0;
            Die();
        }

        UpdateUI();
        Debug.Log("Player Lifes: " + currentLives);
    }

    void Die()
    {
        // Load another scene (replace "YourSceneName" with the actual scene name)
        SceneManager.LoadScene("Starter Scene");
        // You can also use SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex) to reload the current scene.
    }

    void UpdateUI()
    {
        // Update UI logic here (if needed)
    }
}
