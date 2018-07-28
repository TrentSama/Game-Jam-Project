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
    Animator anim;

    // Variables for if an enemy can shoot at the player 
    public float delayBetweenShots;
    public float shootRange;    
    public Transform shootTransform;
    public GameObject projectile;

    public float invincibilityTime = 3f;

    private int timer;


    // Use this for initialization
    void Start () {
        // Initializing the health of the enemy
        enemyCurrentHealth = enemyStartingHealth;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        target = GameObject.Find("Player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        if (target.position.x - transform.position.x > 0)
        {
            this.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else
        {
            this.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        if (distanceToTarget < chaseRange)
        {           
           transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);           
        }
        if (distanceToTarget > despawnRange)
        {
            Object.Destroy(enemy);
        }
        if (distanceToTarget < shootRange)
        {
            timer++;
            if (timer > 500)
        {
                anim.SetTrigger("Attack");
                StartCoroutine(ShootDelay());
                anim.SetTrigger("Attack");
                timer = 0;
             }
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
        if (enemyCurrentHealth <= 0)
        {
            Object.Destroy(enemy);
        }
    }

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(2.2f);
    }

    void Shooting()
    {       
        Instantiate(projectile, shootTransform.position, shootTransform.rotation);       
    }
}

