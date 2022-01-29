using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**=====================================
Class VictoryLogic
-------------------------
Description

Victory logic. Display the victory menu
--------------------------
Author(s):
Bryan Curchod
=====================================*/
public class VictoryLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("VictoryFlag")){
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
