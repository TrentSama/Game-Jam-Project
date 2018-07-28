using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
    public float speed; // Experiment with this to what feels right - 3f;
    public int damage; // the damage this projectile does to the player
    Animator anim;
    AudioSource explosion;

    private Rigidbody2D rb;
    private int timeLimit; // the counter that goes every frame
    private float timer = 200; // The Time it takes for the projectile to disappear on its own
    



    private PlayerManager playerManager;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerManager = FindObjectOfType<PlayerManager>();
        anim = GetComponent<Animator>();
        explosion = GetComponent<AudioSource>();
    }
	

	void FixedUpdate () {
        timeLimit++;
        if (timeLimit > timer)
        {
            Destroy(this.gameObject);
        }
        rb.velocity = transform.up * speed;
    }


    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetTrigger("Hit");
            explosion.Play();
            Destroy(GetComponent<Collider2D>());
            yield return new WaitForSeconds(0.30f);
            Destroy(this.gameObject);
            playerManager.PlayerHealth -= damage;
        }
    }

}
