using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int waterAmount;
    public int waterAmountMax;
    public Text waterText;
	public int PlayerHealth;
    public int PlayerHealthMax;
	public Text PlayerHealthText;
    public int money = 0;
    public int keys = 0;

	[HideInInspector]
	public bool hasWater;

    // Update is called once per frame


    void Update () {
		PlayerHealthText.text = "Health: " + PlayerHealth;
        waterText.text = "Water: " + waterAmount;

		if (Input.GetKeyDown (KeyCode.X)) {
			PlayerHealth -= 1;
		}

        if (waterAmount >= waterAmountMax)
        {
            waterAmount = waterAmountMax;
        }

	}

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage; 
    }

}
