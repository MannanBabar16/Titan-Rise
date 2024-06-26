using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillCountController : MonoBehaviour {
    public static KillCountController instance; // Singleton instance
    public TextMeshProUGUI killsText; // Reference to the kills TextMeshProUGUI
    public TextMeshProUGUI statusText; // Reference to the status TextMeshProUGUI (for Game Over or You Won)
    public int winKillCount = 24; // Number of kills required to win
    public TextMeshProUGUI loadingText;

    private int killCount = 0;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    public void UpdateKillCount() {
        killCount++;
        killsText.text = "Kills: " + killCount;
        Debug.Log("kills: " + killCount);

        // Check if the player has won
        if (killCount >= winKillCount) {
            WinGame();
        }
    }

    public void GameOver() {
        statusText.text = "Game Over!!!";
        statusText.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        StartCoroutine(RestartSceneAfterDelay(1f));
    }

    public void WinGame() {
        statusText.text = "You Won!";
        statusText.gameObject.SetActive(true);
        loadingText.gameObject.SetActive(true);
        SceneManager.LoadScene(("Arcade Level 2"));
    }

    private IEnumerator RestartSceneAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(("SpaceShooter Level 4"));
    }
}
