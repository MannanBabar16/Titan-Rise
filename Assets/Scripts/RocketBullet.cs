using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour {
    private void LateUpdate() {
        if (gameObject.transform.position.y > 3) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("EnemyRocket")) {
            Destroy(gameObject); // Destroy the bullet
            KillCountController.instance.UpdateKillCount(); // Update the kill count
        }
    }
}
