using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent (typeof (NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class HumanoidFollow : MonoBehaviour {

    private Animator animator;
    private NavMeshAgent agent;
    public GameObject player;
    private float catchDistance = 0.5f;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = true;
        agent.destination = player.transform.position;
        animator.SetBool("move", true);
	}
	
	// Update is called once per frame
	void Update () {
        if ((transform.position - agent.destination).magnitude <= catchDistance)
        {
            animator.SetBool("move", false);
            agent.destination = transform.position;
        } else if (animator.GetBool("move"))
        {
            agent.destination = player.transform.position;
            animator.SetFloat("v_speed", agent.desiredVelocity.magnitude);
        }
	}

    private void OnAnimatorMove()
    {
        transform.position = agent.nextPosition;
    }
}
