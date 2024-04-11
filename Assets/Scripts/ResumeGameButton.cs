using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGameButton : MonoBehaviour {
    private GameManager gameManager; // Reference to the GameManager

    private void Start() {
        // Find the GameManager instance in the scene
        gameManager = GameManager.instance;

        // Ensure the GameManager reference is not null
        if (gameManager == null) {
            Debug.LogError("GameManager reference not found.");
        }
    }

    // Function called when the "Resume Game" button is clicked
    public void OnResumeButtonClicked() {
        // Call the GameManager's ResumeGame method to resume the game
        if (gameManager != null) {
            gameManager.ResumeGame();
        }
        else {
            Debug.LogError("GameManager reference is null. Cannot resume game.");
        }
    }
}

