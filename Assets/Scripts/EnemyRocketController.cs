using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyRocketController : MonoBehaviour {
    public GameObject rocketPrefab; // Reference to the rocket prefab
    public float speed = 7f; // Speed of the enemy rocket
    public float minX = -2f; // Minimum x position
    public float maxX = 2f; // Maximum x position



    void Start() {
        // Start spawning enemy rockets
        StartCoroutine(SpawnEnemyRockets());
    }

    IEnumerator SpawnEnemyRockets() {
        while (true) {
            // Randomly set the initial position of the enemy rocket within the specified boundaries
            float randomX = Random.Range(minX, maxX);

            Vector3 spawnPosition = new Vector3(randomX, 3f, 2.06f);

            // Instantiate the rocket prefab at the random position
            GameObject enemyRocket = Instantiate(rocketPrefab, spawnPosition, Quaternion.identity);
         

            enemyRocket.transform.rotation = Quaternion.Euler(180f, 0f, 0f);

            // Move the enemy rocket downwards
            enemyRocket.GetComponent<Rigidbody>().velocity = Vector3.down * speed*Time.deltaTime;

            // Wait for 3 seconds before spawning the next enemy rocket
            yield return new WaitForSeconds(1.2f);
        }
    }

   
}
