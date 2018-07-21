using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbsorb : MonoBehaviour {
    public Animator animator;
    private PlayerController playerController;
    private PlayerManager playerManager;
    private Hydration hydration;
    public float water = 0;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>() ;
    }

    private void Update()
    {
        StartCoroutine(Absorb());

        if (Input.GetKeyDown(KeyCode.F))
        {
            animator.SetTrigger("Absorb");
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HasWater" && playerManager.waterAmount <= 100)
        {
            Debug.Log ("has water");
            hydration = collision.GetComponentInChildren<Hydration>();
            playerManager.waterAmount += hydration.wetnessAmount;
        }
        
    }

    public IEnumerator Absorb()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        if (Input.GetButtonDown("Fire3"))

            if (playerController.busy == true)
            {
                yield return null;
            }

            else if (playerController.busy == false)
            {
                playerController.busy = true;
                animator.SetTrigger("Absorb");
                yield return new WaitForSeconds(0.6f);
                animator.SetTrigger("Absorb");
                playerController.busy = false;
            }
    }
}
