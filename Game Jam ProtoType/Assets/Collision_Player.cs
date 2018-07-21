using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Collision_Player : MonoBehaviour
{


    private Rigidbody2D rb;
    public Animator animator;
    private PlayerManager playerManager;
    private PlayerController playerController;

    [HideInInspector]
    public bool canMove = true;
    public float transitionSpeed;
    [HideInInspector]
    public float invincibilityTime = 1;
    public bool invincible;
    public bool busy;

    public float knockback;
    public float knockbackCount;
    public bool knockFromRight;

    public SpriteRenderer testSprite;
    private Vector2 vex;

    // Use this for initialization
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        playerManager = FindObjectOfType<PlayerManager>();
        playerController = FindObjectOfType<PlayerController>();
        vex = new Vector2(knockback, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (invincible == true)
        {
            testSprite.enabled = true;
        }
        else
        {
            testSprite.enabled = false;
        }

    }

    public IEnumerator OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Hazard")
        {
            yield return null;
        }
        if (collision.tag == "Hazard" && invincible == false)
        {

            if (knockFromRight)
            {
                invincible = true;
                playerController.canMove = false;
                playerManager.TakeDamage(2);
                vex = new Vector2(-knockback, 0f);
                for (int i = 0; i < knockbackCount; i++)
                {
                    rb.AddForce(vex);
                    yield return null;
                }
                playerController.canMove = true;
                yield return new WaitForSeconds(invincibilityTime);
                invincible = false;
            }
            else if (!knockFromRight)
            {
                invincible = true;
                playerController.canMove = false;
                playerManager.TakeDamage(2);
                vex = new Vector2(knockback, 0f);
                for (int i = 0; i < knockbackCount; i++)
                {
                    rb.AddForce(vex);
                    yield return null;
                }
                playerController.canMove = true;
                yield return new WaitForSeconds(invincibilityTime);
                invincible = false;
            }
        }
    }
}
