using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed as needed

    void Update()
    {
        // Get input for movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalMovement, verticalMovement, 0f).normalized;

        // Move the character
        MoveCharacter(moveDirection);
    }

    void MoveCharacter(Vector3 moveDirection)
    {
        // Apply movement to the Transform component
        Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
