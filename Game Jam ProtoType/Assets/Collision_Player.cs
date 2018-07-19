using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Player : MonoBehaviour
{


    private Rigidbody2D rb;
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

    // Use this for initialization
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        playerManager = FindObjectOfType<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Hazard")
        {
            yield return null;
        }
        if (collision.tag == "Hazard" && collision.tag != "PlayerAbsorb" && invincible == false)
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
