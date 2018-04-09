using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCookie : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        GameObject collidingObject = collider.gameObject;
        if (collidingObject.layer == 8)
        {
            GameState.FoundCollectible();
            Destroy(this.gameObject);
        }
    }
}
