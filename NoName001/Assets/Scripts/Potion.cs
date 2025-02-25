using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player playerController = other.GetComponent<Player>();
        if (playerController != null && playerController.getHealth < playerController.maxHealth)
        {
            string potionName = gameObject.name;
            if (potionName == "HP Potion 2")
            {
                playerController.ChangeHealth(1);
            }
            if (potionName == "HP Potion 1")
            {
                playerController.ChangeHealth(2);
            }
            Destroy(gameObject);
        }
        else
            Debug.Log("Max HP");
    }
}
