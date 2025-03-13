using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trap : MonoBehaviour
{
    /*private void OnTriggerStay2D(Collider2D other)
    {
        Player playerController = other.GetComponent<Player>();
        if (playerController != null)
        {
            playerController.ChangeHealth(-1);
        }
    }*/
    public int dmg;
    Coroutine coroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null && coroutine == null) 
        {
            coroutine = StartCoroutine(DealDmg(player));
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null && coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator DealDmg(Player player)
    {
        while (true)
        {
            player.ChangeHealth(-1);
            yield return new WaitForSeconds(1);
        }
    }
}
