using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public float speed; // Experiment with this to what feels right - 3f;
    public int damage; // the damage this projectile does to the player


    private int timeLimit; // the counter that goes every frame
    private float timer = 2000; // The Time it takes for the projectile to disappear on its own
    private Transform target; // Target the missile is heading towards, ie; player
    private Vector2 lookTarget;

    private PlayerManager playerManager;

    // Use this for initialization
    void Start () {


    }
	

	void Update () {

    }

    private void SeekAndDestroy()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(this.gameObject);
            playerManager.PlayerHealth -= damage;
        }
    }

}
