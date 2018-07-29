using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBoi : MonoBehaviour {

	public DialogTrigger olddialog;
	public DialogTrigger newdialog;
	public GameObject body;
	public int toll;
	private PlayerManager pm;
	private bool rich;

	// Use this for initialization
	void Start () {
		pm = FindObjectOfType<PlayerManager> ();
		rich = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (pm.money > toll) {
			rich = true;
			olddialog.enabled = false;
			newdialog.enabled = true;
			body.SetActive (false);
		}
	}
		
	void OnTriggerEnter2D (Collider2D col) {
		if (rich && Input.GetButtonDown ("Fire1")) {
			body.SetActive (false);
		}
	}

}
