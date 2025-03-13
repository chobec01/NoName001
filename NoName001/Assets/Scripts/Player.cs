using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1f;
    Rigidbody2D rb2D;
    public int maxHealth = 10;
    int currentHealth;
    /*public float timeInvincible = 1.0f;
    bool isInvincible;
    float dmgCD;*/

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
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
        Debug.Log(currentHealth + "/" + maxHealth);
    }
    public int getHealth { get { return currentHealth; } }
}
