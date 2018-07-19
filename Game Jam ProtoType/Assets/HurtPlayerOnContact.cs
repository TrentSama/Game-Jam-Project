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
        Collision_Player collision_Player = player.GetComponent<Collision_Player>();
        if (collision.tag != "Player")
        {
            return;
        }
        else
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
