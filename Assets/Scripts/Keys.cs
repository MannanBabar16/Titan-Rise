using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keys : MonoBehaviour {

    public GameObject portalEffect;
    public float rotationSpeed = 50f; // Speed of rotation
    public float moveDistance = 0.5f; // Distance to move up and down
    public float moveSpeed = 1f; // Speed of up and down movement
    private Vector3 initialPosition; // Initial position of the oxygen tank

    void Start() {
        // Store the initial position of the oxygen tank
        initialPosition = transform.position;
    }

    void Update() {
        // Rotate the oxygen tank around its y-axis
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        // Move the oxygen tank up and down
        float newY = initialPosition.y + Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

       
    }


    private void OnTriggerEnter(Collider other) {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player")) {
            // Get reference to the KeySystem
            KeySystem keySystem = FindObjectOfType<KeySystem>();

            // Increment the key count

                keySystem.CollectKey();
                

            // Optionally, deactivate or remove the key GameObject
            gameObject.SetActive(false);
            portalEffect.SetActive(true);
        }
    }
}

