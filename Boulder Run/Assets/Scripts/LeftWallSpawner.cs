using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftWallSpawner : MonoBehaviour {

	// Use this for initialization

	public GameObject LeftWall;

	public GameObject Wall;

	GameObject instLWall;

	Vector3 LeftPos;

	void Start () {

		LeftPos = LeftWall.transform.position;

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider obj){

		Invoke ("spawnWall",0);

	}

	void spawnWall(){

		instLWall = Instantiate (Wall, LeftPos,Quaternion.identity);

	}
}
