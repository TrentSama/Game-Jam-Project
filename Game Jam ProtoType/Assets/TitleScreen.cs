using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreen : MonoBehaviour {

    public Text title;

    public void Start()
    {
        title.text = "Legend of cute water";
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Opening Cutscene");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
    }

}
