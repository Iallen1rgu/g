using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Finish : MonoBehaviour
{
    public GameObject youWinText; // Reference to "You Win" message
    public AudioClip finishSound; // Reference to finish sound effect
    private GameTimer gameTimer; // Reference to GameTimer

    void Start()
    {
        // Find the GameTimer script in the scene
        gameTimer = FindObjectOfType<GameTimer>();
        if (gameTimer == null)
        {
            Debug.LogError("GameTimer script is not found in the scene!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Win!");
            youWinText.SetActive(true); // Show the "You Win!" message

            // Stop the timer and log the elapsed time
            if (gameTimer != null)
            {
                gameTimer.StopTimer();
                Debug.Log("Time to finish: " + gameTimer.GetElapsedTime() + " seconds");
            }

            // Play the finish sound
            if (finishSound != null)
            {
                AudioSource.PlayClipAtPoint(finishSound, transform.position);
            }
        }
    }
}




