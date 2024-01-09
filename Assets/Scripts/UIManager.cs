using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;  // Declare the static Instance property
    public Text livesText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateLivesText(int lifes)
    {
        livesText.text = "Lifes: " + lifes.ToString();
    }

    // ... (other code)
}
