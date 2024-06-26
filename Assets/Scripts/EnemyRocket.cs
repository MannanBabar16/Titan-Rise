using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour {
    private void LateUpdate() {
        if (gameObject.transform.position.y < -0.5) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            Destroy(gameObject); // Destroy the enemy rocket
            Destroy(other.gameObject); // Destroy the bullet
           
        }

        if (other.CompareTag("Player")) {
            // Trigger game over sequence
            KillCountController.instance.GameOver();
        }
    }
}
