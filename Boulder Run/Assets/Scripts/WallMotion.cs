using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMotion : MonoBehaviour {

	// Use this for initialization

	Rigidbody wallBody;
	float wallSpeed= -50f;

	void Start () {

		wallBody=gameObject.GetComponent<Rigidbody> ();

		wallBody.velocity = new Vector3 (0,0,wallSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision obj){
	
		if(obj.gameObject.tag.Equals("WallKiller")){
		Destroy (gameObject);
		}
	}
}
