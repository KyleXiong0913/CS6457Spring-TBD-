using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTimingController : MonoBehaviour {

    Rigidbody  rigidBody;
    bool       activated;
    bool       wasActivatedAtSomePoint = false;
    int        timeSinceActivation = 0;
    public int maxEnabledTime      = 300;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
        if (activated) {
            timeSinceActivation++;
        }
        if (timeSinceActivation >= maxEnabledTime) {
            DisableCube();
        }
	}

    // my functions
    // will happen when a cube collides with the player
    void EnableCube() {
        rigidBody.isKinematic      = false;
        rigidBody.detectCollisions = true;
        activated                  = true;
        wasActivatedAtSomePoint    = true;
    }

    // will happen after some set amount of time from when the cube collides with the player
    void DisableCube() {
        rigidBody.isKinematic      = true;
        rigidBody.detectCollisions = false;
        activated                  = false;
    }

    void OnTriggerEnter(Collider otherObjectCollider) {
        if (otherObjectCollider.gameObject.tag == "Player" && !wasActivatedAtSomePoint) {
            EnableCube();
        }
    }
}
