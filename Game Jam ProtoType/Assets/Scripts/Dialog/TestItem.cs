using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour {

	public PlayerManager pm;
	private bool active;

	void Start () {
		active = false;
	}

	// Update is called once per frame
	void Update () {
		if (active && Input.GetButtonDown ("Fire1")) {
			pm.hasWater = true;
			this.gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			active = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			active = false;
		}
	}
}
