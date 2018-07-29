using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandrew : MonoBehaviour {

	public Puke puke;
	public Sprite dead;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("PlayerAttack")) {
			this.GetComponent<SpriteRenderer> ().sprite = dead;
			this.GetComponent<DialogTrigger> ().enabled = false;
			puke.satisfied = true;

		}
	}
}
