using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabSounds : MonoBehaviour {
    public AudioSource pincers;
    public AudioClip[] snipSounds;
	// Use this for initialization
	
    void PincerSounds()
    {
        int ran = Random.Range(0, snipSounds.Length);
        pincers.clip = snipSounds[ran];
        pincers.Play();
    }

}
