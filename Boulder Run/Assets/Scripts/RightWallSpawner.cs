using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightWallSpawner : MonoBehaviour {

	// Use this for initialization
	public GameObject RightWall;

	public GameObject Wall;

	GameObject instRWall;

	Vector3 RightPos;

	void Start () {

		RightPos = RightWall.transform.position;

	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider obj){

		Invoke ("spawnWall",0);

	}

	void spawnWall(){

		instRWall = Instantiate (Wall,RightPos,Quaternion.identity);

	}
}

