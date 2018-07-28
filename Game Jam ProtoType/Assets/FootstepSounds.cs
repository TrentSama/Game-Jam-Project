using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSounds : MonoBehaviour {

    AudioSource footSound;
    Collider2D hitbox;
    public AudioClip[] footStepBeach;
    public AudioClip[] footStepWater;
    public AudioClip[] footStepCave;
    private int areaID;
    private int randomStep;

    void Start()
    {
        hitbox = GetComponentInParent<Collider2D>();
        footSound = GetComponent<AudioSource>();
    }

    public void PlayFootStep()
    {
        if (areaID == 1)
        {
            randomStep = Random.Range(0, footStepBeach.Length);
            footSound.clip = footStepBeach[randomStep];
            footSound.Play();
        }
        if(areaID == 2)
        {
            randomStep = Random.Range(0, footStepWater.Length);
            footSound.clip = footStepWater[randomStep];
            footSound.Play();
        }
        if(areaID == 3)
        {
            randomStep = Random.Range(0, footStepCave.Length);
            footSound.clip = footStepCave[randomStep];
            footSound.Play();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "beach")
        {
            areaID = 1;           
        }
        if (collision.tag == "waterpuddle")
        {
            areaID = 2;
        }
        if (collision.tag == "cave")
        {
            areaID = 3;
        }
    }



}
