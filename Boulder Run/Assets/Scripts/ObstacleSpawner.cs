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

		InvokeRepeating ("spawnObs", 1f,1f);
	}

	// Update is called once per frame
	void Update () {

	}

	void spawnObs(){

		instObs = Instantiate (obs, spawnPos, Quaternion.identity);

	}

}
