using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {

	public GameObject controlled;

	void OnTriggerStay2D (Collider2D col) {
		if (col.CompareTag ("Player") && Input.GetKeyDown (KeyCode.C)) {
			Debug.Log ("Switched");
			controlled.gameObject.GetComponent<BoxCollider2D> ().enabled
			= !controlled.gameObject.GetComponent<BoxCollider2D> ().enabled;
		}
	}
}
