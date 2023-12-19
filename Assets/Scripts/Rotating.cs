using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 180f; // Adjust the rotation speed as needed

    void Update()
    {
        // Rotate right when the "E" key is pressed
        if (Input.GetKey(KeyCode.E))
        {
            RotateRight();
        }

        // Rotate left when the "Q" key is pressed
        if (Input.GetKey(KeyCode.Q))
        {
            RotateLeft();
        }
    }

    void RotateRight()
    {
        // Rotate the object to the right
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void RotateLeft()
    {
        // Rotate the object to the left
        transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
    }

}
