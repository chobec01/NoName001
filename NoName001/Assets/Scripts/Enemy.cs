using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speedEnemy = 0.1f;
    public float changeTime = 2f;
    public bool vertical;
    float timer;
    int direction = 1;
    Rigidbody2D rbEnemy;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        timer = changeTime;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
            vertical = Random.value > 0.5f;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rbEnemy.position;
        if(vertical)
        {
            position.y = position.y + speedEnemy * Time.deltaTime * direction;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        else
        {
            position.x = position.x + speedEnemy * Time.deltaTime * direction;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        rbEnemy.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
        if (collision.gameObject.name == "Ground")
        {
            direction = -direction;
        }
    }
}
