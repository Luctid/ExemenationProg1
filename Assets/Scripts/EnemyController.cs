using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    

public class EnemyMovement : MonoBehaviour
{
    
    public float moveSpeed = 3f; // Adjust the speed as needed
    public float changeDirectionInterval = 2f; // Time interval to change direction

    private void Start()
    {
        // Start the coroutine to change direction at intervals
        StartCoroutine(ChangeDirectionCoroutine());
    }

    private void Update()
    {
        // Move the enemy in its current direction
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        // Move the enemy based on its current right direction
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
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



