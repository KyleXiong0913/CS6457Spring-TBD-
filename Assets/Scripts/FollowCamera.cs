using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

    public float turnSpeed = 10.0f;
    public Transform player;
    private Vector3 com = new Vector3(0, 1, 0);
    private Vector3 offset;
    private float turnAmount;
    private float epsilon = 0.25f;

    void Start()
    {
        offset = new Vector3(player.position.x, player.position.y + 3.0f, player.position.z - 4.0f);
    }

    void LateUpdate()
    {
        turnAmount = Input.GetAxisRaw("Mouse X");
        if (turnAmount * turnSpeed > epsilon || turnAmount * turnSpeed < -epsilon)
        {
            offset = Quaternion.AngleAxis(turnAmount * turnSpeed, Vector3.up) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position + com);
        } else
        {
            offset = Quaternion.AngleAxis(0, Vector3.up) * offset;
            transform.position = player.position + offset;
            transform.LookAt(player.position + com);
        }
        
    }
}
