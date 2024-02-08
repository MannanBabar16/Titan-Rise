using System.Collections;


using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour {
    public CharacterController controller;
    public Transform cam;

    public float speed = 30f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    Vector3 velocity;


    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    float turnSmoothVelocity;
    public float turnSmoothTime = 0.1f;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        
       
        // Jumping
        if (Input.GetKey(KeyCode.Space) && controller.isGrounded) {
          
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Walking
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f) {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
        else {
            velocity.x = 0;
            velocity.z = 0;
        }

        // Move the player
        controller.Move(velocity * Time.deltaTime);
    }
}