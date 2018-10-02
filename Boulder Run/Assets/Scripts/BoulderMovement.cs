using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMovement : MonoBehaviour {
	Rigidbody rb;
	public Vector3 vel = new Vector3();
	//Vector3 pos = new Vector3();
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = vel;
	}
	
	// Update is called once per frame
	void Update () {
		//rb.velocity = vel;
		//if (transform.position.z >= 0f) {
			//vel.z = 7.5f;
			//rb.velocity = vel;
		//}

	}
}
