using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour {
    private bool isGamePaused = false; // Flag to track if the game is paused

    void Update() {
        // Check if the player presses the escape button
        if (Input.GetKeyDown(KeyCode.Escape)) {
            // Toggle the game pause state
            if (isGamePaused) {
                ResumeGame();
            }
            else {
                PauseGame();
            }
        }
    }

    void PauseGame() {
        // Pause the game
        Time.timeScale = 1;

        // Load the escape menu scene
        SceneManager.LoadScene("Escape Menu");
        
        Cursor.lockState = CursorLockMode.None;


        // Set the game pause flag
        isGamePaused = true;
    }

    public void ResumeGame() {
        // Resume the game
        Time.timeScale = 1;

        // Set the game pause flag
        isGamePaused = false;
    }
}
