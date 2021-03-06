﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PController : NetworkBehaviour {

	public float moveSpeed;
	public float Collisionforce;

	public KeyCode up;
	public KeyCode down;
	public KeyCode lrft;
	public KeyCode right;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
		Vector3 movement;
		if (Input.GetKey (up)) {
			movement = new Vector3 (-moveSpeed, 0, 0);
		} else if (Input.GetKey (down)) {
			movement = new Vector3 (moveSpeed, 0, 0);
		} else if (Input.GetKey (lrft)) {
			movement = new Vector3 (0, 0, -moveSpeed);
		} else if (Input.GetKey (right)) {
			movement = new Vector3 (0, 0, moveSpeed);
		} else
			movement = new Vector3 (0, 0, 0);
		// = Input.GetKey ("Horizental");
		//float VAsix = Input.GetKey ("Vertical");
		//movement = new Vector3 (-hAsix, 0, -VAsix);
		rb.velocity += movement;
	//	}

	}

	void OnCollisionEnter(Collision c)
	{
		
			// If the object we hit is the enemy
			if (c.gameObject.tag == "Player") {
			if (!isServer)
				return;
				if (sizeOfV3 (rb.velocity) > sizeOfV3 (c.gameObject.GetComponent<Rigidbody> ().velocity)) {
					Rigidbody rbB = c.gameObject.GetComponent<Rigidbody> ();
					Vector3 forceA = rb.mass * rb.velocity;
					Vector3 forceB = rbB.mass * rbB.velocity;
					// Calculate Angle Between the collision point and the player
					Vector3 dir = c.contacts [0].point - transform.position;
					//Vector3 fA = forceA* dir;
					//Vector3 fA
					rbB.AddForce (forceA * Collisionforce);
					// We then get the opposite (-Vector3) and normalize it
					dir = -dir.normalized;
					// And finally we add force in the direction of dir and multiply it by force. 
					// This will push back the player
					rb.AddForce (forceB);
					//c.gameObject.GetComponent<Rigidbody>().AddForce (-dir.normalized * Collisionforce);
				}
			//}
		}
	}
	float sizeOfV3 (Vector3 v3){
		return (v3.x * v3.x + v3.y * v3.y + v3.z * v3.z);
	}

	[Command]
	void CmdCollisionH()
	{
		//GameObject ballClone = Instantiate(snowBall,throwPoint.position,throwPoint.rotation) as GameObject;
		//ballClone.transform.localScale = scale;
		//NetworkServer.Spawn (ballClone);
	}
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballscr : MonoBehaviour {

	public float moveSpeed;

	public KeyCode up;
	public KeyCode down;
	public KeyCode lrft;
	public KeyCode right;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 movement;
		if (Input.GetKey (up)){
			movement = new Vector3 (-moveSpeed, 0, 0);
		}
		else if (Input.GetKey (down)){
			movement = new Vector3 (moveSpeed, 0, 0);
		}
		else if (Input.GetKey (lrft)){
			movement = new Vector3 (0, 0, -moveSpeed);
		}
		else if (Input.GetKey (right)){
			movement = new Vector3 (0, 0, moveSpeed);
		}
		else movement = new Vector3 (0, 0, 0);
		// = Input.GetKey ("Horizental");
		//float VAsix = Input.GetKey ("Vertical");
		//movement = new Vector3 (-hAsix, 0, -VAsix);
		rb.velocity += movement;

	}
}
*/