using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestNPC : MonoBehaviour {

	public DialogTrigger noWater;
	public DialogTrigger hasWater;
	public PlayerManager pm;
	
	// Update is called once per frame
	void Update () {
		if (pm.hasWater) {
			noWater.enabled = !enabled;
			hasWater.enabled = enabled;
		}
	}
}
