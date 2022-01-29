using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**=====================================
Class JumperScript
-------------------------
Description: 

Jumper units logic. Propulse the player upward
--------------------------
Author(s):
Edin Karakurt
=====================================*/
public class JumperScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * 15f, ForceMode2D.Impulse);
        }
    }
}

