using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puke : MonoBehaviour {

	public bool satisfied;
	public GameObject reward;
	public DialogTrigger olddialog;
	public DialogTrigger newdialog;

	// Use this for initialization
	void Start () {
		satisfied = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (satisfied) {
			reward.SetActive (true);
			olddialog.enabled = false;
			newdialog.enabled = true;
		}
	}
}
