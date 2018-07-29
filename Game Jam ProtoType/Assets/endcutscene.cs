using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endcutscene : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(EndScene());
	}
	

    IEnumerator EndScene()
    {
        yield return new WaitForSeconds(24);
        SceneManager.LoadScene("Overworld");
    }

}
