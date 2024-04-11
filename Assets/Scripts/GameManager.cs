using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    private string lastActiveSceneName; // Name of the last active scene
    private bool isGamePaused = false; // Flag to indicate if the game is paused

    private void Awake() {

        // Singleton pattern to ensure only one instance of GameManager exists
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }

    private void Start() {
        // Subscribe to scene loading events
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Event handler for scene loading
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name != "Escape Menu") {
            // Update the last active scene name when a non-escape menu scene is loaded
            lastActiveSceneName = scene.name;

            if (isGamePaused) {
                // If the game was paused, resume it after loading the scene
                ResumeGame();
            }
        }
    }

    // Save player progress
    private void SavePlayerProgress() {
        // Save player data (e.g., position, remaining lives, oxygen level, key count) using PlayerPrefs or other method
        PlayerPrefs.SetString("LastActiveScene", lastActiveSceneName);
        // Additional saving logic here
    }

    // Load player progress
    private void LoadPlayerProgress() {
        // Load player data (e.g., position, remaining lives, oxygen level, key count) from PlayerPrefs or other method
        lastActiveSceneName = PlayerPrefs.GetString("LastActiveScene", "Sea Level 1");
        // Additional loading logic here
    }

    // Go to escape menu
    public void GoToEscapeMenu() {
        SavePlayerProgress(); // Save player progress before going to escape menu
        SceneManager.LoadScene("Escape Menu");
    }

    // Resume game from escape menu
    public void ResumeGame() {
        LoadPlayerProgress(); // Load player progress before resuming the game
        SceneManager.LoadScene(lastActiveSceneName);
        Debug.Log("Scene is Loading");
    }

    // Pause or unpause the game
    public void TogglePauseGame() {
        isGamePaused = !isGamePaused;

        if (isGamePaused) {
            Time.timeScale = 0; // Pause the game
            GoToEscapeMenu(); // Go to escape menu when game is paused
        }
        else {
            Time.timeScale = 1; // Unpause the game
            ResumeGame(); // Resume the game from the last active scene
        }
    }

    public void RestartGame() {
        SceneManager.LoadScene("Sea Level 1");
    }

    public void GameOver() {
       
        
        SceneManager.LoadScene("Sea Level 1");
    }
}
