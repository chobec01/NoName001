using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis ("Vertical");
        Vector2 movement = new Vector2(x, y);
        transform.Translate (movement * playerSpeed * Time.deltaTime);
    }
}
