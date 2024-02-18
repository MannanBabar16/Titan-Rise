using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class OxygenSystem : MonoBehaviour {
    public float maxOxygen = 100f;
    public float oxygenDecayRate = 0.5f; // Oxygen decreases by this rate per second
    public float oxygenRecoveryAmount = 50f; // Amount of oxygen recovered by picking up an oxygen container
    public TextMeshProUGUI oxygenDisplay; // UI text to display oxygen percentage
    //public GameObject deathEffect; // Particle effect for player's death

    private float currentOxygen;
    private bool isPlayerDead;

    private void Start() {
        currentOxygen = maxOxygen;
        UpdateOxygenDisplay();
    }

    private void Update() {
        if (!isPlayerDead) {
            // Decrease oxygen over time
            currentOxygen -= oxygenDecayRate * Time.deltaTime;
            UpdateOxygenDisplay();

            // Check if oxygen has depleted
            if (currentOxygen <= 0) {
                OxygenOver();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        // If player collides with oxygen container, refill oxygen and destroy the container
        if (other.CompareTag("OxygenContainer")) {
            currentOxygen += oxygenRecoveryAmount;
            if (currentOxygen > maxOxygen) {
                currentOxygen = maxOxygen;
            }
            UpdateOxygenDisplay();
            Destroy(other.gameObject);
        }
    }

    private void OxygenOver() {
        // Perform actions when player dies (e.g., play death effect, disable player controls)
        
        LivesSystem ls = FindObjectOfType<LivesSystem>();
        if (ls.GetCurrentLives() <= 0) {
            isPlayerDead = true;
        }
        ls.LoseLife();
        // Display death effect
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        // Optionally, disable player controls or respawn player
    }

    private void UpdateOxygenDisplay() {
        // Update UI text to display oxygen percentage
        oxygenDisplay.text = "Oxygen: " + Mathf.Round(currentOxygen) + "%";
    }

    public float CurrentOxygenPercentage() {
        // Calculate and return the current oxygen percentage
        return currentOxygen / maxOxygen * 100f;
    }

    public void ResetOxygen() {
        // Reset the current oxygen value to the maximum value
        currentOxygen = maxOxygen;
    }
}

