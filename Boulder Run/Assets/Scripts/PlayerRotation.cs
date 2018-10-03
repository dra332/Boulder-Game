using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
	public GameObject boulder;
	public KeyCode slow;
	public KeyCode fast;
	public KeyCode jump;
	public KeyCode forward;
	public KeyCode back;
	public int speed;
	HingeJoint hinge;
	SpringJoint spring;
	Light myLight;
	Vector3 vel = new Vector3();
	Vector3 pos = new Vector3();
	Rigidbody rb;
	Rigidbody br;
	bool hasJoint;
	bool hasJump;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		vel.y = 7f;
		hinge = GetComponent<HingeJoint> ();
		br = boulder.GetComponent<Rigidbody> ();
		hasJoint = true;
		hasJump = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (forward)) {
			transform.RotateAround (boulder.transform.position, Vector3.right, speed * Time.deltaTime);
		}
		if (Input.GetKey (back)) {
			transform.RotateAround (boulder.transform.position, Vector3.right, -(speed * Time.deltaTime));
		}

		if (transform.position.z - boulder.transform.position.z >= 0) {
			transform.RotateAround (boulder.transform.position, Vector3.right, (speed * Time.deltaTime)/5f);
		} else if (transform.position.z - boulder.transform.position.z < 0) {
			transform.RotateAround (boulder.transform.position, Vector3.right, -(speed * Time.deltaTime)/5f);
		}

		if (Input.GetKeyDown (jump) && hasJump == false) {
			hasJump = true;
			Destroy (hinge);
			hasJoint = false;
			rb.constraints = RigidbodyConstraints.FreezeRotation;
			rb.isKinematic = false;
			gameObject.AddComponent<SpringJoint> ();
			spring = GetComponent<SpringJoint> ();
			spring.enableCollision = false;
			spring.connectedBody = br;
			spring.spring = 10f;
			spring.anchor = Vector3.zero;
			pos = transform.position;
			rb.AddForce (vel, ForceMode.Impulse);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Control") && hasJoint == false) {
			Destroy (spring);
			//transform.position = pos;
			rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
			gameObject.AddComponent<HingeJoint> ();
			hinge = GetComponent<HingeJoint> ();
			hinge.connectedBody = br;
			hinge.autoConfigureConnectedAnchor = false;
			hinge.connectedAnchor = new Vector3 (0f, 0.8226668f, -0.011f);
			hasJoint = true;
			hasJump = false;
			rb.isKinematic = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Control") && hasJump == true) {
			spring.enableCollision = true;
			Debug.Log ("connected");

		}
	}
}
