using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAbsorb : MonoBehaviour {
    public Animator animator;
    private PlayerController playerController;

    public float water = 0;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        StartCoroutine(Absorb());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HasWater")
        {
            water += 20;
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

                animator.SetTrigger("Absorb");
                playerController.busy = true;
                yield return new WaitForSeconds(1f);
                playerController.busy = false;
                animator.SetTrigger("Absorb");
            }
    }
}
