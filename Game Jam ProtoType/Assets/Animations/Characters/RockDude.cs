using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDude : MonoBehaviour {

	public GameObject body;
	public DialogTrigger oldtext;
	public DialogTrigger newtext;
	public GameObject reward;
	private float newpos;
	private bool used = false;


	
	// Update is called once per frame
	void Update () {
		if (body.activeSelf) {
			newpos = body.transform.position.x;
			if (this.transform.position.x >= -22f) {
				this.transform.position = new Vector3 (newpos, this.transform.position.y);
			} else {
				this.transform.position = new Vector3 (-22f, this.transform.position.y);
				body.transform.position = new Vector3 (this.transform.position.x,
						this.transform.position.y);
			}
		}
		if (body.activeSelf == false && used) {
			oldtext.enabled = false;
			newtext.enabled = true;
			reward.SetActive (true);
		}
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Player") && !used && Input.GetButtonDown("Fire1")) {
			body.SetActive (true);
			used = true;
		}
	}
}
