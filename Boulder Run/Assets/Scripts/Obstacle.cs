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

		gameObject.transform.eulerAngles = new Vector3 (0f, 0f, 90f);

		//Time.timeScale = 0.5f;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider obj){

		if(obj.gameObject.tag.Equals("ObstacleKiller")){
			Destroy (gameObject);
		}
	}

	public void stop(){
	
		obsBody.velocity = new Vector3 (0f, 0f, 0f);
	
	}
}
