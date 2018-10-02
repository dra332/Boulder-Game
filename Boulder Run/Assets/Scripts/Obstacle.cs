using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	Rigidbody obsBody;
	float obsSpeed= -50f;

	void Start () {

		obsBody=gameObject.GetComponent<Rigidbody> ();

		obsBody.velocity = new Vector3 (0,0,obsSpeed);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider obj){

		if(obj.gameObject.tag.Equals("ObstacleKiller")){
			Destroy (gameObject);
		}
	}
}
