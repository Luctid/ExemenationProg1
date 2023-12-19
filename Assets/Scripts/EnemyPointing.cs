using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointing : MonoBehaviour
{
    public float moveSpeed = 3f; // Adjust the speed as needed
    public float changeDirectionInterval = 2f; // Time interval to change direction
    public Transform player; // Reference to the player's transform

    private void Start()
    {
        // Start the coroutine to change direction at intervals
        StartCoroutine(ChangeDirectionCoroutine());

        // Find the player object by tag if not assigned
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("PlayerController").transform;
        }
    }

    private void Update()
    {
        // Rotate towards the player
        RotateTowardsPlayer();

        // Move the enemy in its current direction
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        // Move the enemy based on its current right direction
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsPlayer()
    {
        // Calculate the direction to the player
        Vector2 directionToPlayer = player.position - transform.position;

        // Calculate the angle to rotate towards the player
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;

        // Rotate the enemy towards the player
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private IEnumerator ChangeDirectionCoroutine()
    {
        while (true)
        {
            // Wait for the specified interval
            yield return new WaitForSeconds(changeDirectionInterval);

            // Change the direction randomly
            ChangeDirection();
        }
    }

    private void ChangeDirection()
    {
        // Randomly choose a new rotation in the Z-axis (2D)
        float randomRotationZ = Random.Range(0f, 360f);

        transform.rotation = Quaternion.Euler(0f, 0f, randomRotationZ);
    }
}
