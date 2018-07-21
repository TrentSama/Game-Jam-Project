using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    public Rigidbody2D rb;
    public float speed;
    public Animator animator;
    private PlayerManager playerManager;
    private WaterAbsorb waterAbsorb;

    [HideInInspector]
    public bool canMove = true;
    public float transitionSpeed;
    [HideInInspector]
    public float invincibilityTime = 3f;
    public bool invincible;
    public bool busy; 

    public float knockback;
    public float knockbackLength;
    public float knockbackCount;
    public bool knockFromRight;

    public int damage = 1000;
    public GameObject projectile;
    public Transform projectileTransform;



    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
	
	// Update is called once per frame
	void Update () {

        Moving();
        StartCoroutine(MeleeAttack());
        StartCoroutine(WaterGun());
    }

    public IEnumerator MeleeAttack()
    {
        if (Input.GetButtonDown("Fire2") && knockbackCount <= 0)
            if (busy == true)
            {
                yield return null;
            }
        else if (busy == false)
        {
            busy = true;
            animator.SetTrigger("Attack");
            yield return new WaitForSeconds(0.1f);           
            animator.SetTrigger("Attack");
            busy = false;
        }
    }

    public IEnumerator WaterGun()
    {
        if (Input.GetButtonDown("Fire4"))
        {
            if (busy == true)
            {
                yield return null;
            }
            else if (busy == false && playerManager.waterAmount == 100)
            {
                busy = true;
                playerManager.waterAmount -= 100;
                animator.SetTrigger("Shoot");
                yield return new WaitForSeconds(0.2f);
                animator.SetTrigger("Shoot");
                busy = false;
            }
        }
    }

    public void Moving()
    {
        if (canMove == true && knockbackCount <= 0)
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


    void Projectile()
    {
        Instantiate(projectile, projectileTransform);
    }
 }
    

