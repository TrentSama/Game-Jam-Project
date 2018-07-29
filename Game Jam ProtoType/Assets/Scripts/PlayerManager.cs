using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public int waterAmount;
    public int waterAmountMax;
    public Text waterText;
	public Animator WaterIcon;
	public int PlayerHealth;
    public int PlayerHealthMax;
	public Text PlayerHealthText;
	public Animator HealthIcon;

    private int maxMoney = 100;
    public int money = 0;
	public Text moneyText;
    public int keys = 0;

	[HideInInspector]
	public bool hasWater;
    public Transform respawnPoint;

    // Update is called once per frame

     void Start()
    {

    }

    void Update () {
		PlayerHealthText.text = "" + PlayerHealth;
		HealthIcon.SetInteger ("Health", PlayerHealth);
        waterText.text = "" + waterAmount;
		WaterIcon.SetInteger ("Water", waterAmount);
		moneyText.text = "" + money;

        if (waterAmount >= waterAmountMax)
        {
            waterAmount = waterAmountMax;
        }

        if (PlayerHealth >= PlayerHealthMax)
        {
            PlayerHealth = PlayerHealthMax;
        }

        Death();
	}

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage; 
    }


    public void Death()
    {
        if (PlayerHealth <= 0 )
        {
            transform.position = respawnPoint.position;
            PlayerHealth = PlayerHealthMax;
        }
    }


}
