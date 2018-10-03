using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMovement : MonoBehaviour {
	bool run;
	Rigidbody rb;
	Vector3 pos = new Vector3();
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		run = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (run == true) {
			pos = transform.position;
			pos.z += 0.5f;
			transform.position = pos;
		}
	}

	public void DeathSpeed()
	{
		rb.useGravity = false;
		rb.isKinematic = true;
		run = true;

	}
}
