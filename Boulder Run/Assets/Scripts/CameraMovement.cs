using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public GameObject player;
	public Transform pla;
	Vector3 temp; 
	// Use this for initialization
	void Start () {
		temp = new Vector3(-6f, 4.85f, (player.transform.position.z -5f));
	}
	
	// Update is called once per frame
	void Update () {
		temp.z = player.transform.position.z - 5f;
		transform.position = temp;
		//transform.LookAt (pla);
	}
}
