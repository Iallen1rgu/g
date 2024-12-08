using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the projectile collides with an enemy
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log("Projectile hit an enemy!");
            
            // Destroy the enemy
            Destroy(collision.gameObject);

            // Destroy the projectile itself
            Destroy(gameObject);
        }
    }
}

