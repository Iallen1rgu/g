using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform destination; // Destination of the portal

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player enters the portal
        {
            Debug.Log("Player entered the portal!");
            other.transform.position = destination.position; // Teleport the player
        }
    }
}

