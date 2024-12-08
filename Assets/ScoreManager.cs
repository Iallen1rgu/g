using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class ScoreManager : MonoBehaviour
{
    public int score = 0; // Keeps track of the score
    public TextMeshProUGUI scoreText; // Reference to the ScoreText UI element

    void Start()
    {
        UpdateScoreUI(); // Initialize the score display
    }

    public void AddScore(int value)
    {
        score += value; // Increase the score
        UpdateScoreUI(); // Update the score display
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the visible text
        }
    }
}


