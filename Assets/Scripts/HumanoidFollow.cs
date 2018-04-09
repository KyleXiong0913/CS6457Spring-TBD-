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
    private float catchDistance     = 0.5f;
    private bool  waitingAtStart    = true;
    private int   timeSpentWaiting  = 0;
    public  int   timeToWaitAtStart = 200;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateRotation = true;
	}

	// Update is called once per frame
	void Update () {
        if (waitingAtStart)
        {
            timeSpentWaiting++;
            if (timeSpentWaiting >= timeToWaitAtStart)
            {
                animator.SetBool("move", true);
                agent.destination = player.transform.position;
                waitingAtStart = false;
            }
        }

        if ((transform.position - player.transform.position).magnitude <= catchDistance)
        {
            animator.SetBool("move", false);
            agent.destination = transform.position;
            // TODO testing
            Debug.Log("GOT HERE");
            GameState.LoseGame();
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
