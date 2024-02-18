using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {

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
        // Check if the player collides with the lives object
        if (other.CompareTag("Player")) {
            // Increase the number of lives
            LivesSystem livesSystem = FindObjectOfType<LivesSystem>();
            if (livesSystem != null) {
                livesSystem.GainLife();
            }

     
            gameObject.SetActive(false);
        }
    }
}

