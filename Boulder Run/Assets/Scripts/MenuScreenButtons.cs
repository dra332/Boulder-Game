﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour {

	// Use this for initialization

	public AudioSource select;

	public AudioClip selectSound;

	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape)) {

			Application.Quit();

		}

	}

	public void quitGame(){

		Application.Quit();

	}

	public void toPlayLevel(){

		SceneManager.LoadScene ("Level1");// change to appropriate scene name

	}

	public void toMenu(){

		SceneManager.LoadScene ("MainMenu");

	}

	public void resetLevel(){

		SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);

	}

	public void playsound (){

		select.PlayOneShot (selectSound, 1);

	}
}
