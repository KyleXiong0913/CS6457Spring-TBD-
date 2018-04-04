using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour {

    public GameObject waypoint;

    UnityEngine.AI.NavMeshAgent navMeshAgent;
    Animator     anim;

	// Use this for initialization
	void Start () {
	    navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        if (navMeshAgent == null) {
            Debug.Log("couldnt get the NavMeshAgent");
        }

        anim = GetComponent<Animator>();

        if (anim == null) {
            Debug.Log("couldnt get the Animator");
        }
	}

	// Update is called once per frame
	void Update () {
        // follow the waypoint
        navMeshAgent.SetDestination(waypoint.transform.position);
	}
}
