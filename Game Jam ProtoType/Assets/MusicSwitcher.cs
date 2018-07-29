using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSwitcher : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip gameMusicBeach;
    public AudioClip gameMusicTown;
    public AudioClip creepySong;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameMusicBeach;
        audioSource.Play();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "MusicBeach")
        {
            if (audioSource.clip != gameMusicBeach)
            {
                audioSource.clip = gameMusicBeach;
                audioSource.Play();
            }

        }
        if (collision.tag == "MusicTown")
        {
            if (audioSource.clip != gameMusicTown)
            {
                audioSource.clip = gameMusicTown;
                audioSource.Play();
            }
        }
        if (collision.tag == "HellaCreepy")
        {
            if (audioSource.clip != creepySong)
            {
                audioSource.clip = creepySong;
                audioSource.Play();
            }
        }
    }

}
