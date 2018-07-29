using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {
    Canvas optionsCanvas;
    public Canvas pauseCanvas;

    private void Start()
    {
        optionsCanvas = GetComponent<Canvas>();
    }

    public void OptionsPanel()
    {
        pauseCanvas.enabled = !pauseCanvas.enabled;
        optionsCanvas.enabled = !optionsCanvas.enabled;
    }

}
