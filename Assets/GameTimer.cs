using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // Reference to Timer Text
    private float timer = 0f; // Initialize timer
    private bool isTimerRunning = true; // Control timer

    void Update()
    {
        if (isTimerRunning)
        {
            timer += Time.deltaTime; // Increment timer
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            timerText.text = "Time: " + timer.ToString("F2");
        }
        else
        {
            Debug.LogError("TimerText is not assigned!");
        }
    }

    // Method to stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Method to get the elapsed time
    public float GetElapsedTime()
    {
        return timer;
    }
}



