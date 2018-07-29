using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

	public GameObject dollar;
	public GameObject popsicle;
	private Animator anim;
	private bool opened;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		opened = false;
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.CompareTag ("PlayerAttack") && !opened) {
			SpawnLoot ();
			opened = true;
		}
	}

	void SpawnLoot () {
		anim.SetBool ("open", true);

		Vector3 position = new Vector3(this.transform.position.x, 
			this.transform.position.y);
		int dollars = Random.Range (1, 7);
		for (int i = 0; i < dollars; i++) {
			float pointx = Random.Range (-0.75f, 0.25f);
			float pointy = Random.Range (-0.75f, 0.25f);
			Vector3 spawnpoint = new Vector3 (pointx, pointy);
			Instantiate (dollar, position + spawnpoint, Quaternion.identity);
		}

		int popsicles = Random.Range (0, 4);
		for (int i = 0; i < popsicles; i++) {
			if (i >= 2) {
				float pointx = Random.Range (-0.75f, 0.25f);
				float pointy = Random.Range (-0.75f, 0.25f);
				Vector3 spawnpoint = new Vector3 (pointx, pointy);
				Instantiate (popsicle, position + spawnpoint, Quaternion.identity);
			}
		}
	}
}
