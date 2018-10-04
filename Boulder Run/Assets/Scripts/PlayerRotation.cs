using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {
	Animator anim;
	public CameraMovement cm;
	public BoulderMovement bm;
	public MenuControl mc;
	public GameObject charMod;
	public GameObject boulder;
	public KeyCode slow;
	public KeyCode fast;
	public KeyCode jump;
	public KeyCode forward;
	public KeyCode back;
	public float speed;
	HingeJoint hinge;
	SpringJoint spring;
	public Vector3 vel = new Vector3();
	Vector3 pos = new Vector3();
	Rigidbody rb;
	Rigidbody br;
	bool hasJoint;
	bool hasJump;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = charMod.GetComponent<Animator> ();
		hinge = GetComponent<HingeJoint> ();
		br = boulder.GetComponent<Rigidbody> ();
		hasJoint = true;
		hasJump = false;
		hinge.enableCollision = true;
	}

	// Update is called once per frame
	void Update () {
		if (mc.hasStart == true) {
			if (Input.GetKey (forward) && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, speed * Time.deltaTime);
				anim.SetBool ("Running", true);
				anim.SetBool ("Breath", false);
			}
			if (Input.GetKey (back) && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, -(speed * Time.deltaTime));
				anim.SetBool ("Breath", false);
				anim.SetBool ("Running", true);
			}
			if (Input.GetKey (forward) && Input.GetKey (slow) && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, (speed - 50f) * Time.deltaTime);
				anim.SetBool ("Breath", false);
				anim.SetBool ("Running", true);
			}
			if (Input.GetKey (back) && Input.GetKey (slow) && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, -((speed - 50f) * Time.deltaTime));
				anim.SetBool ("Breath", false);
				anim.SetBool ("Running", true);
			}
			if (Input.GetKey (forward) && Input.GetKey (fast) && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, (speed * 1.1f) * Time.deltaTime);
				anim.SetBool ("Breath", false);
				anim.SetBool ("Running", true);
			}
			if (Input.GetKey (back) && Input.GetKey (fast) && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, -((speed * 1.1f) * Time.deltaTime));
				anim.SetBool ("Breath", false);
				anim.SetBool ("Running", true);
			}

			if (transform.position.z - boulder.transform.position.z >= 0 && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, (speed * Time.deltaTime) / 5f);
			} else if (transform.position.z - boulder.transform.position.z < 0 && cm.dead == false) {
				transform.RotateAround (boulder.transform.position, Vector3.right, -(speed * Time.deltaTime) / 5f);
			}

			if (Input.GetKeyDown (jump) && hasJump == false) {
				hasJump = true;
				Destroy (hinge);
				hasJoint = false;
				rb.constraints = RigidbodyConstraints.FreezeRotation;
				rb.isKinematic = false;
				gameObject.AddComponent<SpringJoint> ();
				spring = GetComponent<SpringJoint> ();
				spring.enableCollision = true;
				spring.connectedBody = br;
				spring.spring = 10f;
				spring.anchor = Vector3.zero;
				rb.AddForce (vel, ForceMode.Impulse);
				anim.SetBool ("Running", false);
				anim.SetBool ("Breath", false);
				anim.SetBool ("Jump", true);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Control") && hasJoint == false) {
			Destroy (spring);
			rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
			gameObject.AddComponent<HingeJoint> ();
			hinge = GetComponent<HingeJoint> ();
			hinge.connectedBody = br;
			hinge.autoConfigureConnectedAnchor = false;
			hinge.connectedAnchor = new Vector3 (0f, 0.8226668f, -0.011f);
			hinge.enableCollision = true;
			hasJoint = true;
			hasJump = false;
			rb.isKinematic = true;
			anim.SetBool ("Running", true);
			anim.SetBool ("Jump", false);
		}


	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag ("Control") && hasJump == true) {
			spring.enableCollision = true;
		}
	}
}
