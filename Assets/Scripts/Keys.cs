using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player")) {
            // Get reference to the KeySystem
            KeySystem keySystem = FindObjectOfType<KeySystem>();

            // Increment the key count

                keySystem.CollectKey();
            

            // Optionally, deactivate or remove the key GameObject
            gameObject.SetActive(false);
        }
    }
}

