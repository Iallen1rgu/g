using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
     public AudioClip collectibleSound; // Reference to the collectible sound
    void OnTriggerEnter2D(Collider2D collision)

    {
        Debug.Log("Triggered by: " + collision.gameObject.name); // Log the name of the object

        if (collision.CompareTag("Player")) // Detect the player
        {
            Debug.Log("Player detected!");
            Debug.Log("Player collected item");

            // Add to the score via the ScoreManager
            GameObject.Find("GameManager").GetComponent<ScoreManager>().AddScore(1);

            // Debug message
            Debug.Log("Item collected!");

            // Play the collectible sound
            AudioSource.PlayClipAtPoint(collectibleSound, transform.position);

            // Destroy the collectible
            Destroy(gameObject);
        }
    }
}

