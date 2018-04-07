using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHitForce : MonoBehaviour {

    public float scaleFactor = 300.0f; // Changes how strong the applied force is


    void Start () {
    }

    // This collider will apply a force to everything inside it when a swing happens
    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.layer != 8) // ensures the collider cannot add force to the player
        {
            Rigidbody body = collider.gameObject.GetComponent<Rigidbody>();
            Vector3 direction = collider.gameObject.transform.position - transform.position;
            body.AddForceAtPosition(direction * scaleFactor, transform.position);
        }   
    }
}
