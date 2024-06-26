using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour {
    public GameObject bulletPrefab; // Prefab for the bullet
    public Transform bulletSpawnPoint; // Spawn point for the bullet
    public float bulletSpeed = 25f; // Speed of the bullet
    public float speed = 5.0f; // Movement speed of the rocket
    public float boundaryX = 2.5f; // Horizontal screen boundary
    public float boundaryYMax = 2.1f; // Maximum vertical screen boundary
    public float boundaryYMin = -0.1f; // Minimum vertical screen boundary

    void Update() {
        // Get input for movement in horizontal (x) and vertical (y) axes
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calculate the movement direction based on input
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);

        // Move the rocket based on the calculated movement direction and speed
        transform.Translate(movement * speed * Time.deltaTime);

        // Clamp the rocket's position to stay within the screen boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -boundaryX, boundaryX);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, boundaryYMin, boundaryYMax);
        transform.position = clampedPosition;

        if (Input.GetKeyDown(KeyCode.Space)) {
            Shoot();
        }
        

    }

    


    void Shoot() {
        // Instantiate a bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // Get the rigidbody component of the bullet
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        // Set the velocity of the bullet to move along the y axis
        bulletRb.velocity = transform.up * bulletSpeed*Time.deltaTime;

    }


}


