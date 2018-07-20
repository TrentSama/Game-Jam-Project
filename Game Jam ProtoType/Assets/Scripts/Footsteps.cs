using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {

	public AudioClip[] beachsteps;
	private AudioSource src;
	private bool playable;


	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource> ();
		playable = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (playable && (Input.GetAxisRaw ("Horizontal") != 0 
			|| Input.GetAxisRaw ("Vertical") != 0)) {
			StartCoroutine (PlaySound ());
		}
	}

	IEnumerator PlaySound () {
		playable = false;
		int step = Random.Range (0, 4);
		src.clip = beachsteps [step];
		src.Play();
		yield return new WaitForSeconds(0.5f);
		playable = true;
	}
}
