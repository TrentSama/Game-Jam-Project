using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private int timer;

	// Update is called once per frame
	void Update () {
		timer++;
		if (timer > 120) {
			Destroy (this.gameObject);
		}
			
		Vector2 move = new Vector2 (0.0f, 0.15f);
		transform.Translate (move);
	}

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Enemy")
          { 
           Destroy(this.gameObject);
          }
	}
}
