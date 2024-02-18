using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class KeySystem : MonoBehaviour {
    private int maxKeys = 0; // Default maximum number of keys

    private int currentKeys;
    public TextMeshProUGUI keyUIText;

    void Start() {
        currentKeys = maxKeys;



        // Update the key count text initially
        UpdateKeyText();
    }

    public void CollectKey() {
        // Increase key count by 1
        currentKeys++;

        // Update the key count text
        UpdateKeyText();
    }

    public void UseKey() {
        // Decrease key count by 1
        currentKeys--;

        // Update the key count text
        UpdateKeyText();
    }

    public int GetCurrentKeys() {
        return currentKeys;
    }

    private void UpdateKeyText() {
        // Update the TextMeshPro Text object to show the current number of keys
        if (keyUIText != null) {
            keyUIText.text = "Keys: " + currentKeys.ToString();
        }
    }
}

