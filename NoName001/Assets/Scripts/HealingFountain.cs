using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : MonoBehaviour
{
    /*private void OnTriggerStay2D(Collider2D other)
    {
        Player playerController = other.GetComponent<Player>();
        if (playerController != null)
        {
            playerController.ChangeHealth(1);
        }
    }*/
    public int healMount;
    Coroutine coroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null && coroutine == null)
        {
            coroutine = StartCoroutine(Heal(player));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if(player != null && coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    IEnumerator Heal(Player player)
    {
        while(true)
        {
            player.ChangeHealth(1);
            yield return new WaitForSeconds(1);
        }
    }
}
