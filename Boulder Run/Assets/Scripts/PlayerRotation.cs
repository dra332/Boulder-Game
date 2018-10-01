using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
	public Transform boulder;
	public KeyCode slow;
	public KeyCode fast;
	public KeyCode jump;
	public KeyCode forward;
	public KeyCode back;
	public int speed;
	Vector3 pos = new Vector3();
	Vector3 vel = new Vector3();
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		vel.y = 10f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (forward)) {
			transform.RotateAround (boulder.position, Vector3.right, speed * Time.deltaTime);
		}
		if (Input.GetKey (back)) {
			transform.RotateAround (boulder.position, Vector3.right, -(speed * Time.deltaTime));
		}

		if (transform.position.z >= 0) {
			transform.RotateAround (boulder.position, Vector3.right, (speed * Time.deltaTime)/10f);
		} else if (transform.position.z < 0) {
			transform.RotateAround (boulder.position, Vector3.right, -(speed * Time.deltaTime)/10f);
		}

		if (Input.GetKeyDown (jump)) {
			rb.AddForce (vel, ForceMode.Impulse);
		}
	}
}
