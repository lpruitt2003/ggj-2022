using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/**=====================================
Class DeathLogic
-------------------------
Description:

Death logic. Display the victory menu and disable the player's character
--------------------------
Author(s):
Bryan Curchod
Selin Kaya
=====================================*/
public class DeathLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isImmune = false;

    public StudioEventEmitter deathSound;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (isImmune){
            return;
        }
        
        if(collision.gameObject.CompareTag("DoNotTouch")){
            deathSound.Play();
            Die();
        }
    }

    private void Die(){
        // Debug.Log("haha ya dead lul");

        // TODO  trigger death animation
        //check if player 1 or player 2

        if (gameObject.CompareTag("Player1")){  //player 1 death
            //player 1 death
            GetComponent<PlayerControls>().detachCamera();
            PlayerControls.isAlive = false;
            Player2Controls.isAlive = false;
            
            CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
            collider.enabled = false;
            // rb.bodyType = RigidbodyType2D.Static;
            // gameObject.SetActive(false);
            
            if (LevelManager.instance != null){
                LevelManager.instance.GameOver();
            }        
        }
        else if (gameObject.CompareTag("Player2")){ //player 2 death
            //player 2 death
            GetComponent<Player2Controls>().detachCamera();
            PlayerControls.isAlive = false;
            Player2Controls.isAlive = false;
            
            CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
            collider.enabled = false;
            // rb.bodyType = RigidbodyType2D.Static;
            // gameObject.SetActive(false);

            if (LevelManager.instance != null){
                LevelManager.instance.GameOver();
            }
        }
    }
}
