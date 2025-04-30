using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1f;
    public int maxHealth = 10;
    public int getHealth { get { return currentHealth; } }
    public GameObject projectilePrefab;
    Rigidbody2D rbPlayer;
    int currentHealth;
    Animator animator;
    Vector2 moveDirection = new Vector2 (1, 0);
    /*public float timeInvincible = 1.0f;
    bool isInvincible;
    float dmgCD;*/

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            FindFriend();
        }
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
        rbPlayer.MovePosition(rbPlayer.position + movement);
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

    void Launch()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rbPlayer.position, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>( );
        projectile.Launch(moveDirection,150);
        animator.SetTrigger("Launch");
    }

    void FindFriend()
    {
        RaycastHit2D hit = Physics2D.Raycast(rbPlayer.position, moveDirection, 1.5f, LayerMask.GetMask("NPC"));
        if(hit.collider != null)
        {
            Debug.Log("Raycast has hit the object " + hit.collider.gameObject);
        }
    }
}
