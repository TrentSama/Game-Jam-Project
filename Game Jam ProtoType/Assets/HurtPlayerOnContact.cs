using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

    private Collision_Player collision_Player;

	// Use this for initialization
	void Awake () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Collision_Player collision_Player = player.GetComponentInChildren<Collision_Player>();
    }
	
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }
        else if (collision.tag == "Player")
        {
            // playerController.knockbackCount = playerController.knockbackLength;

            if (collision.transform.position.x < transform.position.x)
            {
                collision_Player.knockFromRight = true;
            }
            else
            {
                collision_Player.knockFromRight = false;
            }
        }       
    }
}
