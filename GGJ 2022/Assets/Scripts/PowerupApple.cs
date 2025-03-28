using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupApple : MonoBehaviour
{
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
        Debug.Log(player.name + " is now immune.");

        if (player.CompareTag("Player1"))
        {
            player.GetComponent<DeathLogic>().isImmune = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (player.CompareTag("Player2"))
        {
            player.GetComponent<DeathLogic>().isImmune = true;
            GetComponent<SpriteRenderer>().enabled = false;
        }

        // after a certain amount of time, the player will no longer be immune to the spikes
        yield return new WaitForSeconds(immunityTime);

        Debug.Log(player.name + "'s immunity has worn off.");

        if (player.CompareTag("Player1"))
        {
            player.GetComponent<DeathLogic>().isImmune = false;
        }
        else if (player.CompareTag("Player2"))
        {
            player.GetComponent<DeathLogic>().isImmune = false;
        }

        DestroyApple();
    }

    void DestroyApple()
    {
        Destroy(gameObject);
    }
}
