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
    // Start is called before the first frame update
    void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    private void FixedUpdate()
    {
        Vector2 position = rbEnemy.position;
        if(vertical)
        {
            position.y = position.y + speedEnemy * Time.deltaTime * direction;
        }
        else
        {
            position.x = position.x + speedEnemy * Time.deltaTime * direction;
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
    }
}
