using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;
    public float thrust;
    [HideInInspector]
    public bool canMove = true;
    public float transitionSpeed;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        Moving();

        if (Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }


	}

    public void Moving()
    {
        if (canMove == true)
        {

            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            Vector2 movement = new Vector2(h, v);
            rb.velocity = (movement * speed);
        }
    }

    IEnumerator TransitionPause()
    {
        canMove = false;
        yield return new WaitForSeconds(transitionSpeed);
        canMove = true;
    }

}
