using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {

    public AudioMixerSnapshot unpaused;
    public AudioMixerSnapshot paused;

    Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Submit"))
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
	}

    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass();
    }

    void Lowpass()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(.01f);
        }

        else

        {
            unpaused.TransitionTo(.01f);
        }
    }

    public void Quit()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        SceneManager.LoadScene("TitleScreen");
    }
}
