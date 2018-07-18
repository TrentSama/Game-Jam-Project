using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

	public int PlayerHealth;
	public Text PlayerHealthText;

    // Update is called once per frame


    void Update () {
		PlayerHealthText.text = "Health: " + PlayerHealth;

		if (Input.GetKeyDown (KeyCode.X)) {
			PlayerHealth -= 1;
		}
	}

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage; 
    }

}
