using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour {
    private int enemyStartingHealth = 100;
    public int enemyCurrentHealth;
    public int enemyDamage;
    public float timeBetweenAttack;
    public Collider2D despawnRadius;
    public GameObject enemy;
    private Transform target;
    public float speed;
    public float chaseRange;

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
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Object.Destroy(enemy);
        }
    }
}
