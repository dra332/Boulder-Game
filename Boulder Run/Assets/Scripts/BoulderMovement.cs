using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderMovement : MonoBehaviour {
	Rigidbody rb;
	public Vector3 vel = new Vector3();
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		rb.velocity = vel;
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = vel;
	}
}
