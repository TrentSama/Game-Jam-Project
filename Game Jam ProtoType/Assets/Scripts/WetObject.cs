using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WetObject : MonoBehaviour {

	public Sprite other;
	public bool wet;

	// Use this for initialization
	void Start () {
		wet = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (wet) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = other;
		}
	}

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log ("touched");
	}
}
