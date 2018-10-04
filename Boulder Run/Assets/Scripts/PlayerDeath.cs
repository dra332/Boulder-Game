using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
	public CameraMovement cm;
	public BoulderMovement bm;
	public MenuControl mc;
	public GameObject charMod;
	Rigidbody rb;
	HingeJoint hinge;
	Animator anim;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		hinge = GetComponent<HingeJoint> ();
		anim = charMod.GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (cm.dead == true) {
			transform.position = new Vector3 (0f, 0.5f, -17f);
			transform.rotation = Quaternion.identity;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			anim.SetBool ("Running", false);
			anim.SetBool ("Breath", true);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Death Zone")) {
			Destroy (hinge);
			cm.dead = true;
			mc.deathText.gameObject.SetActive (true);
			mc.otherDeath.gameObject.SetActive (true);
			bm.DeathSpeed ();
		}
	}
}
