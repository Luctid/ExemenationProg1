using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionHandler : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the player collides with an enemy bullet
        if (other.CompareTag("Enemy bullet"))
        {
            // Load another scene when hit by an enemy bullet
            SceneManager.LoadScene("DIe");
        }
    }
}
