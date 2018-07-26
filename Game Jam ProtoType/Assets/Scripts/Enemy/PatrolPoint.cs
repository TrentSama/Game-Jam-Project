using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolPoint : MonoBehaviour {

    private EnemyPatroler enemyPatroler;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Patroller")
        {
            enemyPatroler = collision.GetComponent<EnemyPatroler>();
            if (enemyPatroler.currentPatrolIndex + 1 < enemyPatroler.patrolPoints.Length)
            {
                enemyPatroler.currentPatrolIndex++;
            }
            else
            {
                enemyPatroler.currentPatrolIndex = 0;
            }
            enemyPatroler.currentPatrolPoint = enemyPatroler.patrolPoints[enemyPatroler.currentPatrolIndex];
        }
    }

}
