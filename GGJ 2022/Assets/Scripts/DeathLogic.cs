using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathLogic : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("DoNotTouch")){
                Die();
        }
    }

    private void Die(){
        // Debug.Log("haha ya dead lul");

        // TODO  trigger death animation
        LevelManager.instance.GameOver();
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.SetActive(false);
    }
}
