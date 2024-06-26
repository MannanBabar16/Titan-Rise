using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Portal2 : MonoBehaviour {
    public KeySystem keySystem; // Reference to the KeySystem script
    public ParticleSystem portalParticles; // Reference to the ParticleSystem of Portal1
    public GameObject errorMessageText; // Reference to the error message TextMeshPro GameObject


    private void OnTriggerEnter(Collider other) {
        PlayPortalParticles();
        if (other.CompareTag("Player")) {
            if (keySystem.GetCurrentKeys() > 0) {
                // Decrease the key count by 1
                keySystem.UseKey();

                // Load the scene "Puzzle Level 2"
                SceneManager.LoadScene("News Level 3");
            }
            else {
                ShowErrorMessage();
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player")) {
            // Hide the error message and pause particles
            HideErrorMessage();
           // PausePortalParticles();
        }
    }

    private void ShowErrorMessage() {
        // Activate the error message text GameObject
        errorMessageText.SetActive(true);
    }

    private void HideErrorMessage() {
        // Deactivate the error message text GameObject
        errorMessageText.SetActive(false);
    }

    private void PlayPortalParticles() {
        // Play the particle system
        portalParticles.Play();
    }

    private void PausePortalParticles() {
        // Pause the particle system
        portalParticles.Pause();
    }

    private void ResumePortalParticles() {
        // Resume the particle system
        portalParticles.Play();
    }


}