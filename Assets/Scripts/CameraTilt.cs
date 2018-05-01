using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTilt : MonoBehaviour {

    public GameObject player;
    Vector3 heightOffset = new Vector3(0f, 2.0f);
    float height = 2.0f;
    float followDistance;
    float tiltSpeed = 50;
    float smoothing = 100;
    Vector3 firstPos;

    // Use this for initialization
    void Start () {
        followDistance = (player.GetComponent<Transform>().position - GetComponent<Transform>().position).magnitude;
        Vector3 playerPos = player.GetComponent<Transform>().position;
        Vector3 cameraPos = GetComponent<Transform>().position;
    }
	
	// Update is called once per frame
	void Update () {
		
        if (!GameState.GamePaused() && !GameState.GameWon() && !GameState.GameLost())
        {
            float tiltValue = Input.GetAxisRaw(GameState.cameraVAxis); 
            if (tiltValue <= 0.05 && tiltValue >= -0.05)
            {
                tiltValue = Input.GetAxisRaw(GameState.cameraVKey)/3.0f;
            }
            // add height & rotate x direction
            if (tiltValue >= 0.05 || tiltValue <= -0.05)
            {
                //angle = angle + ((tiltValue * 10) * scaleValue * Time.deltaTime);
                //Transform playerTransform = player.GetComponent<Transform>();
               // Vector3 playerPos = playerTransform.position;
                //Vector3 playerForward = playerTransform.forward;
                //Vector3 newPos = playerPos - (playerTransform.forward * followDistance);
                height -= tiltValue * tiltSpeed * Time.deltaTime;
                //newPos.y += height;

                //Vector3 newPos = playerPos + new Vector3(0, Mathf.Sin(((angle * Mathf.PI) / 180)) * followDistance, - Mathf.Cos((angle * Mathf.PI) / 180) * followDistance);

                //GetComponent<Transform>().position = newPos;

                //Quaternion newRotation = Quaternion.LookRotation(playerPos - newPos + heightOffset);
                //transform.rotation = newRotation;
            }

            float maxFollowDistance = followDistance;

            //angle = angle + ((tiltValue * 10) * scaleValue * Time.deltaTime);
            Transform playerTransform = player.GetComponent<Transform>();
            Vector3 playerPos = playerTransform.position;
            Vector3 playerForward = playerTransform.forward;
            Vector3 firstPos = playerPos - (playerTransform.forward * followDistance);
            //height += Input.GetAxisRaw(GameState.cameraVAxis) * 5 * Time.deltaTime;
            firstPos.y += height;


            //Vector3 newPos = playerPos + new Vector3(0, Mathf.Sin(((angle * Mathf.PI) / 180)) * followDistance, - Mathf.Cos((angle * Mathf.PI) / 180) * followDistance);

            //GetComponent<Transform>().position = firstPos;

            Quaternion newRotation = Quaternion.LookRotation(playerPos - firstPos + heightOffset);
            transform.rotation = newRotation;

            RaycastHit hit;
            Vector3 newPos = firstPos;

            while (Physics.Raycast(newPos, transform.forward, out hit, maxFollowDistance + 2))
            {
                if (!hit.collider.CompareTag("Player") && maxFollowDistance > 0)
                {
                    maxFollowDistance -= 0.1f;
                } else
                {
                    break;
                }
                newPos = playerPos - (playerTransform.forward * maxFollowDistance);
                newPos.y += height;
            }

            GetComponent<Transform>().position = Vector3.Lerp(firstPos, newPos, smoothing * Time.deltaTime);

            newRotation = Quaternion.LookRotation(playerPos - newPos + heightOffset);
            transform.rotation = newRotation;


        }
	}
}
