using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
	public GameObject player;
	public Transform pla;
	float shakeDuration;
	public float shakeAmount;
	public float decreasaeAmount;
	[HideInInspector]
	public bool dead;
	Vector3 temp; 
	Vector3 originalPos;
	// Use this for initialization
	void Start () {
		shakeDuration = 1f;
		dead = false;
		originalPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
			transform.LookAt (pla);
		if (dead == true) {
			if (shakeDuration > 0) {
				temp.x = originalPos.x + Random.Range (-0.5f, 0.5f) * shakeAmount;
				temp.y = originalPos.y + Random.Range (-0.5f, 0.5f) * shakeAmount;
				temp.z = originalPos.z;
				this.transform.localPosition = temp;
				shakeDuration -= Time.deltaTime * decreasaeAmount;
			}
			else {
				this.transform.position = originalPos;
			}
		}
	}
}

