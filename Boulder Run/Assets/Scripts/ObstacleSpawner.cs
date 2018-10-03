using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	// Use this for initialization

	public GameObject obs;

	Vector3 spawnPos;

	GameObject instObs;

	void Start () {
	
		spawnPos = gameObject.transform.position;
	
	}

	// Update is called once per frame
	void Update () {

	}

	public void spawnObs(){

		instObs = Instantiate (obs, spawnPos, Quaternion.identity);

	}

}
