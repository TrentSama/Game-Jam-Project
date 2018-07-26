using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {
    Canvas optionsCanvas;

    private void Start()
    {
        optionsCanvas = GetComponent<Canvas>();
    }

    public void OptionsPanel()
    {
        optionsCanvas.enabled = !optionsCanvas.enabled;
    }

}
