using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingscript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform shootingPoint;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Check if the shooting point and bullet prefab are set
        if (shootingPoint != null && bulletPrefab != null)
        {
            // Instantiate a new bullet at the shooting point position and rotation
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Shooting point or bullet prefab is not set.");
        }
    }
}
