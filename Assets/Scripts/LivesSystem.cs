using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LivesSystem : MonoBehaviour {

    private int maxLives = 2; // Default maximum number of lives
    private int currentLives = 2;
    public OxygenSystem oxygenSystem;
    public TextMeshProUGUI livesUIText;


    void Start() {

        UpdateLivesText();
        currentLives = maxLives;

    }

    public void LoseLife() {
        // Decrease lives by 1
        currentLives--;

        // Check if lives have run out
        if (currentLives <= 0) {
            Dies();
        }
        else {
            // Reset oxygen and refill oxygen tank
            oxygenSystem.ResetOxygen();
            UpdateLivesText();
        }
    }

    public void GainLife() {
        // Increase lives by 1
        currentLives++;
        UpdateLivesText();
    }

    private void UpdateLivesText() {
        // Update the TextMeshPro Text object to show the current number of lives
        if (livesUIText != null) {
            livesUIText.text = "Lives: " + currentLives;
        }
           
        
    }

    public int GetCurrentLives() {
        return currentLives;
    }


    public void Dies() {
        GameManager gm = FindObjectOfType<GameManager>();
        gm.GameOver();
    }
}

