using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        Player playerController = other.GetComponent<Player>();
        if (playerController != null)
        {
            playerController.ChangeHealth(-1);
        }
    }
}
