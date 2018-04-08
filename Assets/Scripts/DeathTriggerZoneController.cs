using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTriggerZoneController : MonoBehaviour {
    void OnTriggerEnter(Collider otherObjectCollider) {
        if (otherObjectCollider.gameObject.tag == "Player") {
            Debug.Log("DEAD!");
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
