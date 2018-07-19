using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;
    public float thrust;
    public Animator animator;
    private PlayerManager playerManager;

    [HideInInspector]
    public bool canMove = true;
    public float transitionSpeed;
    [HideInInspector]
    public float invincibilityTime = 3f;
    public bool invincible;
    public bool busy; 

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    public int damage = 1000;

    public Collider2D collider1;
    public Collider2D collider2;
    public Collider2D collider3;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
	
	// Update is called once per frame
	void Update () {

        Moving();
        StartCoroutine(MeleeAttack());       
    }

    public IEnumerator MeleeAttack()
    {
        if (Input.GetButtonDown("Fire2") && knockbackCount <= 0)
            if (busy == true)
            {
                yield return null;
            }
        else if (busy == false)
        {
            animator.SetTrigger("Attack");
            busy = true;
            yield return new WaitForSeconds(0.1f);
            busy = false;
            animator.SetTrigger("Attack");
        }
    }



    public void Moving()
    {
        if (canMove == true && knockbackCount <= 0)
        {

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(h, v);
            rb.velocity = (movement * speed);
        }
    }

    IEnumerator TransitionPause()
    {
        canMove = false;
        yield return new WaitForSeconds(transitionSpeed);
        canMove = true;
    }

    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Hazard")
        {
            yield return null;
        }
        if (collision.tag == "Hazard" && collision.tag != "PlayerAbsorb" &&  invincible == false)
        {

            if (knockFromRight)
            {
                invincible = true;
                playerManager.TakeDamage(2);
                knockbackCount = 1;
                GetComponent<Rigidbody2D>().velocity﻿ = new Vector2(-knockback, 0f);
                yield return new WaitForSeconds(knockbackLength);
                knockbackCount = 0;
                yield return new WaitForSeconds(invincibilityTime);
                invincible = false;
            }
            else if (!knockFromRight)
            {
                invincible = true;
                playerManager.TakeDamage(2);
                knockbackCount = 1;
                GetComponent<Rigidbody2D>().velocity﻿ = new Vector2(knockback, 0f);               
                yield return new WaitForSeconds(knockbackLength);
                knockbackCount = 0;
                yield return new WaitForSeconds(invincibilityTime);
                invincible = false;
            }
        }
    }
}
