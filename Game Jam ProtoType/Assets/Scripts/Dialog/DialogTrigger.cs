using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

	public Dialog dialog;
	private DialogManager dm;
	private bool active;

	void Start () {
		dm = FindObjectOfType<DialogManager> ();
		active = false;
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") && active) {
			if (!dm.active) {
				TriggerDialog ();
			}
			else if (dm.active) {
				dm.DisplayNextSentence();
			}
		}
	}

	public void TriggerDialog () {
		dm.StartDialog (dialog);
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
