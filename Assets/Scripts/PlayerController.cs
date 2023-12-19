using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
        public float moveSpeed = 5f; // Adjust the speed as needed
        public float rotationSpeed = 3f; // Adjust the rotation speed as needed

        private Rigidbody rb;

        void Start()
        {
            // Ensure there is a Rigidbody component attached to the GameObject
            rb = GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody component not found. Add a Rigidbody to your GameObject.");
            }
        }

        void Update()
        {
            // Get input for movement
            float horizontalMovement = Input.GetAxis("Horizontal");
            float verticalMovement = Input.GetAxis("Vertical");

            // Calculate movement direction
            Vector3 moveDirection = new Vector3(horizontalMovement, verticalMovement, 0f).normalized;

            // Move the character
            MoveCharacter(moveDirection);

            // Rotate the character based on movement direction
            RotateCharacter(moveDirection);
        }

        void MoveCharacter(Vector3 moveDirection)
        {
            // Apply movement to the Rigidbody
            Vector3 movement = moveDirection * moveSpeed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);
        }

        void RotateCharacter(Vector3 moveDirection)
        {
            // Rotate the character to face the movement direction
            if (moveDirection != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
            }
        }
}

