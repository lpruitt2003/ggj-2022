using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/**=====================================
Class VictoryLogic
-------------------------
Description

Victory logic. Display the victory menu
--------------------------
Author(s):
Bryan Curchod
Selin Kaya
=====================================*/
public class VictoryLogic : MonoBehaviour
{
    private Rigidbody2D rb;

    public StudioEventEmitter victoryMusic;
    public StudioEventEmitter music;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("VictoryFlag")){
            PlayerControls.isAlive = false;
            Player2Controls.isAlive = false;
            Win();
        }

        if (collision.gameObject.CompareTag("VictoryFlagLast"))
        {
            PlayerControls.isAlive = false;
            Player2Controls.isAlive = false;
            music.Stop();
            victoryMusic.Play();
            Win();
        }
    }

    private void Win(){
        // Debug.Log("haha ya dead lul");

        LevelManager.instance.Victory();
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.SetActive(false);
    }
}
