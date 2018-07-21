using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour {
    private int enemyStartingHealth = 100;
    public int enemyCurrentHealth;
    public int enemyDamage;
    public float timeBetweenAttack;
    public GameObject enemy;
    private Transform target;
    public float speed;
    public float chaseRange;
    public float despawnRange;
    public bool invincible;

    public float invincibilityTime = 3f;


    // Use this for initialization
    void Start () {
        // Initializing the health of the enemy
        enemyCurrentHealth = enemyStartingHealth;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        target = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        if (distanceToTarget < chaseRange)
        {           
           transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);           
        }
        if (distanceToTarget > despawnRange)
        {
            Object.Destroy(enemy);
        }
        Death();
    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.tag == "PlayerAttack")
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                PlayerController playerController = player.GetComponent<PlayerController>();
                TakeDamage();
                yield return null;
            }

            if (collision.tag == "PlayerAbsorb")
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                PlayerController playerController = player.GetComponent<PlayerController>();
                
                yield return null;
            }

        }
    }

    void TakeDamage()
    {
        if (invincible == false)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            enemyCurrentHealth -= playerController.damage;
        }
    }

    void Death()
    {
        if (enemyCurrentHealth < 0)
        {
            Object.Destroy(enemy);
        }
    }

}



//}
//        if (collision.tag == "PlayerAttack" && invincible == false && knockbackCount <= 0)
//        {
//            GameObject player = GameObject.FindGameObjectWithTag("Player");
//PlayerController playerController = player.GetComponent<PlayerController>();
//            if (knockFromRight && knockbackCount <= 0)
//            {
//                enemyCurrentHealth -= playerController.damage;
//                Death();
//invincible = true;
//                knockbackCount = 1;
//                GetComponent<Rigidbody2D>().velocity﻿ = new Vector2(-knockback, 0f);
//yield return new WaitForSeconds(knockbackLength);
//knockbackCount = 0;
//                yield return new WaitForSeconds(invincibilityTime);
//invincible = false;
//            }
//            else if (!knockFromRight && knockbackCount <= 0)
//            {
//                enemyCurrentHealth -= playerController.damage;
//                Death();
//invincible = true;
//                knockbackCount = 1;
//                GetComponent<Rigidbody2D>().velocity﻿ = new Vector2(knockback, 0f);
//yield return new WaitForSeconds(knockbackLength);
//knockbackCount = 0;
//                yield return new WaitForSeconds(invincibilityTime);
//invincible = false;
//            }
//        }
