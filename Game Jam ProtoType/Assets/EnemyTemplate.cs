using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemplate : MonoBehaviour {
    private int enemyStartingHealth;
    public int enemyCurrentHealth;
    public int enemyDamage;
    public float timeBetweenAttack;
    public Collider2D despawnRadius;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
        enemyCurrentHealth = enemyStartingHealth; 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Object.Destroy(enemy);
        }
    }
}
