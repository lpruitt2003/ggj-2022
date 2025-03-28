using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupApple : MonoBehaviour
{

    // when either player 1 or player 2 collides with the apple, the player will be immune to the spikes for a short period of time

    public float immunityTime = 5f;
    public GameObject player1;
    public GameObject player2;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player1 || other.gameObject == player2)
        {
            StartCoroutine(Immunity(other.gameObject));
        }
    }

    IEnumerator Immunity(GameObject player)
    {
        if (player.CompareTag("Player1"))
        {
            player.GetComponent<DeathLogic>().isImmune = true;
        }
        else if (player.CompareTag("Player2"))
        {
            player.GetComponent<DeathLogic>().isImmune = true;
        }

        yield return new WaitForSeconds(immunityTime);

        if (player.CompareTag("Player1"))
        {
            player.GetComponent<DeathLogic>().isImmune = false;
        }
        else if (player.CompareTag("Player2"))
        {
            player.GetComponent<DeathLogic>().isImmune = false;
        }
    }
}
