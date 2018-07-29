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
			col.gameObject.SetActive(false);
			this.GetComponent<DialogTrigger> ().enabled = false;
		}
	}

	private bool SamePosition (Transform trans) {
		if (trans.position.x <= this.transform.position.x + 0.5f
			&& trans.position.x >= this.transform.position.x - 0.5f) {
			return true;
		}
		return false;
	}
}
