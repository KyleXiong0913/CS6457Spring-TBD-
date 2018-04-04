using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class BoyMovement : MonoBehaviour {

    public float vertical_speed;
    public float horizontal_speed;
    public float scaleFactor = 3;
    private float movespeed;
    public float rotateDegreesPerSecond = 120.0f;
    private Vector3 direction = Vector3.zero;
    private Animator animator;
    CharacterController CharacterMove;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        CharacterMove = GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update () {
        vertical_speed = Input.GetAxisRaw("Vertical");
        horizontal_speed = Input.GetAxisRaw("Mouse X");

        animator.SetFloat("v_speed", vertical_speed);

        if ((horizontal_speed >= 0.05 || horizontal_speed <= -0.05) && (vertical_speed >= 0.1 || vertical_speed <= -0.1))
        {
            direction = new Vector3(horizontal_speed, 0, 0);
            direction = transform.TransformDirection(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(direction),
                rotateDegreesPerSecond * Time.deltaTime);
        } else
        {
            Debug.Log(horizontal_speed);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation, 0);
        }
        
    }


    private void OnAnimatorMove()
    {
        Vector3 newPosition = transform.position;
        
        if (vertical_speed >= 0)
        {
            movespeed = vertical_speed * scaleFactor;
        } else
        {
            movespeed = vertical_speed;
        }

        Vector3 moveDirection = transform.forward;
        CharacterMove.Move(moveDirection * movespeed * Time.deltaTime);
        //transform.position = newPosition;
        

    }
}

