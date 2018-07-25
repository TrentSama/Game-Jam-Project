using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerLevels : MonoBehaviour {

    public AudioMixer masterMixer;

    public void SetSfxLvl(float sfxLvl)
    {
        masterMixer.SetFloat("effectsVol", sfxLvl);
    }

    public void SetMusicLvl(float musicLvl)
    {
        masterMixer.SetFloat("musicVol", musicLvl);
    }
}
