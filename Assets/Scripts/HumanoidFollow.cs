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
    private Vector2 smoothDeltaPosition = Vector2.zero;
    private Vector2 velocity = Vector2.zero;
    private float catchDistance = 0.5f;


	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.destination = player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if ((transform.position - agent.destination).magnitude <= catchDistance)
        {

        }

        if (animator.GetBool("move"))
        {
            agent.destination = player.transform.position;
            Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

            float dx = Vector3.Dot(transform.right, worldDeltaPosition);
            float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
            Vector2 deltaPosition = new Vector2(dx, dy);

            float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
            smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

            if (Time.deltaTime > 1e-5f)
            {
                velocity = smoothDeltaPosition / Time.deltaTime;
            }

            bool shouldMove = (velocity.magnitude > 0.5f) && (agent.remainingDistance > agent.radius);

            //animator.SetFloat("velx", velocity.x);
            if (velocity.y < 0)
            {
                animator.SetFloat("v_speed", -1);
            }
            else if (velocity.y > 0)
            {
                animator.SetFloat("v_speed", 1);
            }

            GetComponent<Transform>().LookAt(agent.steeringTarget + transform.forward);
        } else
        {

        }
        

	}

    private void OnAnimatorMove()
    {
        transform.position = agent.nextPosition;
    }
}
