using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // For scene management

public class LifeSystem : MonoBehaviour
{
    public int lives = 3; // Total number of lives
    public GameObject[] lifeIcons; // Array of life UI icons
    public GameObject gameOverText; // Reference to the Game Over text UI object

    void Start()
    {
        // Hide the Game Over text at the start of the game
        if (gameOverText != null)
        {
            gameOverText.SetActive(false);
        }
    }

    public void LoseLife()
    {
        if (lives > 0)
        {
            // Decrease lives
            lives--;
            Debug.Log("Lives remaining: " + lives);

            // Update life icons
            if (lifeIcons.Length > 0 && lives < lifeIcons.Length)
            {
                lifeIcons[lives].SetActive(false); // Disable the corresponding life icon
            }

            // Check for Game Over
            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");

        // Show Game Over text
        if (gameOverText != null)
        {
            gameOverText.SetActive(true);
        }

        // Optional: Restart the level after a delay
        Invoke("RestartLevel", 2f); // Restart after 2 seconds
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}


