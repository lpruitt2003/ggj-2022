using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/**=====================================
Class JumperScript
-------------------------
Description: 

Jumper units logic. Propulse the player upward
--------------------------
Author(s):
Edin Karakurt
Selin Kaya
=====================================*/
public class JumperScript : MonoBehaviour
{
    private Animator anim;
    public StudioEventEmitter jumperSound;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            anim.Play("Boing");
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * 15f, ForceMode2D.Impulse);
        }

        jumperSound.Play();
    }
}

