using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRadius = 2f;
    public float explosionForce = 10f;
    public GameObject explosionEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PlayerController"))
        {
            explosion();
        }
    }

    private void explosion()
    {
        // Spawn explosion effect if available
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
        }

        // Get all colliders in the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        // Apply explosion force to nearby objects with Rigidbody2D
        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Calculate direction from the explosion point to the object
                Vector2 direction = (rb.transform.position - transform.position).normalized;

                // Apply explosion force
                rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
            }
        }

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}
