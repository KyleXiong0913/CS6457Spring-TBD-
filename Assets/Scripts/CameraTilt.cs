using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTilt : MonoBehaviour {

    public GameObject player;
    Vector3 heightOffset = new Vector3(0f, 2.0f);
    float angle;
    float scaleValue = 50; // max degrees per second to tilt
    float followDistance;

    // Use this for initialization
    void Start () {
        followDistance = (player.GetComponent<Transform>().position - GetComponent<Transform>().position).magnitude;
        Vector3 playerPos = player.GetComponent<Transform>().position;
        Vector3 cameraPos = GetComponent<Transform>().position;
        angle = (Mathf.Acos((playerPos - cameraPos).z / followDistance) * 180) / Mathf.PI;
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
                angle = angle + ((tiltValue * 10) * scaleValue * Time.deltaTime);
                Vector3 playerPos = player.GetComponent<Transform>().position;
                Vector3 newPos = playerPos + new Vector3(0, Mathf.Sin(((angle * Mathf.PI) / 180)) * followDistance, - Mathf.Cos((angle * Mathf.PI) / 180) * followDistance);

                GetComponent<Transform>().position = newPos;

                Quaternion newRotation = Quaternion.LookRotation(playerPos - newPos + heightOffset);
                transform.rotation = newRotation;
            }   
        }
	}
}
