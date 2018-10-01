using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public KeyCode slow;
	public KeyCode fast;
	public KeyCode jump;
	public KeyCode forward;
	Rigidbody rb;
	Vector3 vel = new Vector3();
	bool onFloor;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (onFloor == true) {
			if (Input.GetKey (forward)) {
				vel.z = 5f;
				rb.velocity = vel;
				if (Input.GetKey (fast)) {
					vel.z = 10f;
					rb.velocity = vel;
				} else if (Input.GetKey (slow)) {
					vel.z = 1f;
					rb.velocity = vel;
				}
			} 
			if (Input.GetKeyDown (jump)) {
				vel.y = 10f;
				rb.velocity = vel;
			} if (transform.position.y >= 5f) {
				vel.y = 0f;
				rb.velocity = vel;
			}
		}
	}


	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Control")) {
			onFloor = false;
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Control")) {
			onFloor = true;
		}
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.CompareTag ("Boulder")) {
			vel.y = 0f;
			rb.velocity = vel;
		}
	}
}
