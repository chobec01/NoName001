using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1f;
    Rigidbody2D rb2D;
    public int maxHealth = 10;
    int currentHealth;
    Animator animator;
    Vector2 moveDirection = new Vector2 (1, 0);
    /*public float timeInvincible = 1.0f;
    bool isInvincible;
    float dmgCD;*/

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        /*if (isInvincible)
        {
            dmgCD -= Time.deltaTime;
            if(dmgCD < 0)
            {
                isInvincible = false;
            }
        }*/
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        if(!Mathf.Approximately(x, 0.0f) || !Mathf.Approximately(y, 0.0f))
        {
            moveDirection.Set(x, y);
            moveDirection.Normalize();
        }
        animator.SetFloat("Move X", moveDirection.x);
        animator.SetFloat("Move Y", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.magnitude);
        Vector2 movement = new Vector2(x, y) * playerSpeed * Time.deltaTime;
        rb2D.MovePosition(rb2D.position + movement);
    }
    public void ChangeHealth(int amount)
    {
        /*if(amount < 0 || amount > 0)
        {
            if(isInvincible)
            {
                return;
            }
            isInvincible = true;
            dmgCD = timeInvincible;
        }*/
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        UIHandler.instance.SetHealthValue(currentHealth / (float)maxHealth);
        animator.SetTrigger("Hit");
    }
    public int getHealth { get { return currentHealth; } }
}
