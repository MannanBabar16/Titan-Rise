using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlayerController : MonoBehaviour {
    public float moveSpeed = 3f;
    public float mouseSensitivity = 60f;

    public Rigidbody rb;
    private Vector3 moveDirection;
    private float mouseX, mouseY;
    public Camera playerCamera;

    private void Start() {
 
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor to center of screen
        
    }

    private void Update() {
        // Player movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDirection = (transform.forward * vertical + transform.right * horizontal).normalized;

        // Mouse look
        mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        transform.localRotation = Quaternion.Euler(mouseY, mouseX, 0f);

        // Move the camera along with the player
        playerCamera.transform.position = transform.position;
        playerCamera.transform.rotation = transform.rotation;
    }

    private void FixedUpdate() {
        // Apply movement to the Rigidbody
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
    }
}
