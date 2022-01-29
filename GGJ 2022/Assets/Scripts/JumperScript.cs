using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperScript : MonoBehaviour
{
    //GameObject go1 = new GameObject();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void jump()
    {
        //print("sick");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Rigidbody rb = collision.GetComponent<Rigidbody>();
            //rb.AddExplosionForce(10.0f, 5.0f, 1.0f, 3.0F);
        }


    }
}

