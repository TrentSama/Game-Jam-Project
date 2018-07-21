using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int direction;
	private int timer;

	// Update is called once per frame
	void Update () {
		timer++;
		if (timer > 120) {
			Destroy (this.gameObject);
		}
			
		Vector3 move = new Vector3 (0.25f * direction, 0.0f);
		transform.Translate (move);
	}

	void OnTriggerEnter2D (Collider2D collision) {
		Destroy (this.gameObject);
	}
}
