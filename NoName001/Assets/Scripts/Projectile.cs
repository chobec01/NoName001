using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rbProjectile;

    private void Awake()
    {
        rbProjectile = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(transform.position.magnitude > 10.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {
        rbProjectile.AddForce(direction *  force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.Fix();
        }
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
