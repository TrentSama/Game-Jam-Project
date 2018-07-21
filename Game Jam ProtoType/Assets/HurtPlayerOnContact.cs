using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerOnContact : MonoBehaviour {

    private Collision_Player collision_Player;

	// Use this for initialization
	void Awake () {
    }
	
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "PlayerHitbox")
        {
            return;
        }
        else if (collision.tag == "PlayerHitbox")
        {
            // playerController.knockbackCount = playerController.knockbackLength;

            if (collision.transform.position.x < transform.position.x)
            {
                collision_Player = collision.GetComponentInChildren<Collision_Player>();
                collision_Player.knockFromRight = true;
            }
            else
            {
                collision_Player = collision.GetComponentInChildren<Collision_Player>();
                collision_Player.knockFromRight = false;
            }
        }       
    }
}
