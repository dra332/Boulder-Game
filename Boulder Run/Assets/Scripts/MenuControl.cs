using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {
	public bool hasStart;
	public GameObject startText;
	public GameObject deathText;
	public GameObject otherDeath;
	public CameraMovement cm;
	public MenuScreenButtons msb;
	// Use this for initialization
	void Start () {
		hasStart = false;
		deathText.SetActive (false);
		otherDeath.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && cm.dead == false) {
			startText.gameObject.SetActive (false);
			hasStart = true;
		}

		if (Input.GetKeyDown (KeyCode.Space) && cm.dead == true) {
			msb.resetLevel ();
		}
	}
}
