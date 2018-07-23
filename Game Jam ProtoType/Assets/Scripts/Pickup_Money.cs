using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Money : MonoBehaviour {

    private PlayerManager playerManager;
    public int moneyAmount;
    // Use this for initialization
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerManager.waterAmount += moneyAmount;
            Object.Destroy(this.gameObject);
        }
    }

}
