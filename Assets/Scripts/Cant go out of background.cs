using UnityEngine;
using UnityEngine.SceneManagement;

public class Cantgooutofbackground : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Constrain the player within the screen boundaries
        float screenWidth = Camera.main.orthographicSize * 2 * Screen.width / Screen.height;
        float screenHeight = Camera.main.orthographicSize * 2;

        float playerHalfWidth = transform.localScale.x / 2;
        float playerHalfHeight = transform.localScale.y / 2;

        float newX = Mathf.Clamp(transform.position.x, -screenWidth / 2 + playerHalfWidth, screenWidth / 2 - playerHalfWidth);
        float newY = Mathf.Clamp(transform.position.y, -screenHeight / 2 + playerHalfHeight, screenHeight / 2 - playerHalfHeight);

        transform.position = new Vector2(newX, newY);

        // Check if the player hits the left wall
        if (transform.position.x <= -screenWidth / 2 + playerHalfWidth)
        {
            // Player hit the left wall, switch to the "Die" scene
            SceneManager.LoadScene("Die");
        }
    }
}
