using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed

    void Update()
    {
        MoveLeft();
    }

    void MoveLeft()
    {
        // Move the object to the left based on its current position and speed
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
