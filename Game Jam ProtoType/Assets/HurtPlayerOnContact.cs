using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

	// Use this for initialization
	void Awake () {
    }
	
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (collision.tag == "Player")
        {
                playerController.knockbackCount = playerController.knockbackLength;

                if (collision.transform.position.x < transform.position.x)
                {
                    playerController.knockFromRight = true;
                }
                else
                {
                    playerController.knockFromRight = false;
                }           
        }
    }



}
