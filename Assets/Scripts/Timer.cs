using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour {
    public float totalTime = 300.0f; // Total time in seconds (5 minutes)
    private float currentTime; // Current time in seconds

    public TextMeshProUGUI timerText; // Reference to the UI Text component to display the timer

    void Start() {
        // Initialize the current time
        currentTime = totalTime;
    }

    void Update() {
        // Update the current time
        currentTime -= Time.deltaTime;

        // Check if the timer has reached zero
        if (currentTime <= 0.0f) {
            // Timer has reached zero, handle the timeout (e.g., restart level)
            Debug.Log("Time's up!");
            currentTime = 0.0f; // Clamp the time to zero to avoid negative values
        }

        // Update the timer display
        UpdateTimerDisplay();
    }

    void UpdateTimerDisplay() {
        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the timer text
        timerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }
}
