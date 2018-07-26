using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatroler : MonoBehaviour {
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

    [HideInInspector]
    public int currentPatrolIndex;
    public Transform[] patrolPoints;
    [HideInInspector]
    public Transform currentPatrolPoint;


    // Variables for if an enemy can shoot at the player 
    public float delayBetweenShots;
    public float shootRange;
    public Transform shootTransform;
    public GameObject projectile;

    public float invincibilityTime = 3f;

    private int timer;


    // Use this for initialization
    void Start()
    {
        // Initializing the health of the enemy
        enemyCurrentHealth = enemyStartingHealth;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerController playerController = player.GetComponent<PlayerController>();
        target = GameObject.Find("Player").transform;
        currentPatrolIndex = 0;
        currentPatrolPoint = patrolPoints [currentPatrolIndex];
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);

        if (distanceToTarget < chaseRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        if (distanceToTarget > chaseRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentPatrolPoint.position, speed * Time.deltaTime);                                
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
                StartCoroutine(Shooting());
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

    IEnumerator Shooting()
    {
        yield return new WaitForSeconds(delayBetweenShots);
        Instantiate(projectile, shootTransform.position, shootTransform.rotation);
    }
}

