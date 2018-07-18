using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;
    public float thrust;
    public Animator animator;

    [HideInInspector]
    public bool canMove = true;
    public float transitionSpeed;
    [HideInInspector]
    public float invincibilityTime = 3f;
    public bool invincible;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    public int damage = 1000;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Moving();
        StartCoroutine(MeleeAttack());
    }

    public IEnumerator MeleeAttack()
    {
        if (Input.GetButtonDown("Fire2") && knockbackCount <= 0)
        {
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.1f);
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
        if (collision.tag == "Hazard" && invincible == false)
        {
            if (knockFromRight)
            {
                invincible = true;
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
                knockbackCount = 1;
                GetComponent<Rigidbody2D>().velocity﻿ = new Vector2(knockback, 0f);               
                yield return new WaitForSeconds(knockbackLength);
                knockbackCount = 0;
                yield return new WaitForSeconds(invincibilityTime);
                invincible = false;
            }
        }
    }

    IEnumerator Cooldown()
    {
        invincible = true;
        yield return new WaitForSeconds(invincibilityTime);
        invincible = false;
    }
}
