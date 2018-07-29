using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup_Money : MonoBehaviour {

    private PlayerManager playerManager;
    private Transform target;
    public int moneyAmount;
    public float followRange;
    public int speed;
    // Use this for initialization
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        target = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, target.position);
        if (distanceToTarget < followRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerManager.money += moneyAmount;
            Object.Destroy(this.gameObject);
        }
    }

}
