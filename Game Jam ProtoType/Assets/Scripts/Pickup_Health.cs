using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Health : MonoBehaviour {

    private PlayerManager playerManager;
    public int healingAmount;
	// Use this for initialization
	void Start () {
        playerManager = FindObjectOfType<PlayerManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerManager.PlayerHealth += healingAmount;
            Object.Destroy(this.gameObject);
        }
    }

}
