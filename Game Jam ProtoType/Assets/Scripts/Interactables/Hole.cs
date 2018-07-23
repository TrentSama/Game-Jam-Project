using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag("Pushable") && SamePosition(col.transform)){
			Destroy (col.gameObject);
		}
	}

	private bool SamePosition (Transform trans) {
		if (trans.position.y <= this.transform.position.y + 0.025f
			&& trans.position.y >= this.transform.position.y - 0.025f
			&& trans.position.x <= this.transform.position.x + 0.025f
			&& trans.position.x >= this.transform.position.x - 0.025f) {
			return true;
		}
		return false;
	}
}
