using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;
    public float thrust;

    [HideInInspector]
    public bool canMove = true;
    public float transitionSpeed;
    [HideInInspector]
    public float invincibilityTime = 1f;
    public bool invincible;

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Moving();

       // if (Input.GetButtonDown("Fire1"))
       // {
        //    rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
      //  }


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

    public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector3 knockbackDir)
    {

        float timer = 0;

        while (knockDur > timer)
        {

            timer += Time.deltaTime;

            rb.AddForce(new Vector2(knockbackDir.x * -100, knockbackDir.y + knockbackPwr));

        }

        yield return 0;

    }


    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hazard" && invincible == false)
        {
            if (knockFromRight)
            {
                knockbackCount = 1;
                GetComponent<Rigidbody2D>().velocity﻿ = new Vector2(-knockback, 0f);
                yield return new WaitForSeconds(knockbackLength);
                knockbackCount = 0;               
            }
            else if (!knockFromRight)
            {
                knockbackCount = 1;
                GetComponent<Rigidbody2D>().velocity﻿ = new Vector2(knockback, 0f);               
                yield return new WaitForSeconds(knockbackLength);
                knockbackCount = 0;
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
