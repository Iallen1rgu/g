using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // The projectile prefab
    public Transform firePoint; // The point where the projectile spawns
    public float projectileSpeed = 10f; // Speed of the projectile

    void Update()
    {
        // Check for attack input
        if (Input.GetKeyDown(KeyCode.F)) // Press F to attack
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            // Create the projectile
            Debug.Log("Instantiating projectile...");
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Add velocity to the projectile
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Debug.Log("Adding velocity to projectile...");
                rb.velocity = transform.right * projectileSpeed; // Move the projectile forward
            }

            // Destroy the projectile after 2 seconds to avoid clutter
            Destroy(projectile, 2f);
        }
        else
        {
            Debug.LogError("ProjectilePrefab or FirePoint is not assigned!");
        }
    }
}

