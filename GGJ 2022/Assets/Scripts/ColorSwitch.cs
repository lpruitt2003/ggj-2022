using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/**=====================================
Class ColorSwitch
-------------------------
Description:

Switch the colours of the environment between B&W and coloured. Handle the Sound effects.
Some game elements are enabled/disabled depending on the mode
--------------------------
Author(s):
Selin Kaya
Bryan Curchod
Johan Bergström
=====================================*/
public class ColorSwitch : MonoBehaviour
{
    // Colors
    Color32 darkBlue = new Color32(36, 52, 58, 255);
    Color32 mediumBlue = new Color32(62, 153, 184, 255);
    Color32 lightBlue = new Color32(149, 194, 209, 255);

    // Bool that will check the state of the environment
    public bool isEnvironmentColored;

    //Sound effects
    public StudioEventEmitter colorswap;

    // For holding the colored objects inside the level
    private GameObject[] darkColoredObjects;
    private GameObject[] mediumColoredObjects;
    private GameObject[] lightColoredObjects;

    // START
    // - Will fetch the colored objects according to their tags
    void Start()
    {
        isEnvironmentColored = true;

        darkColoredObjects = GameObject.FindGameObjectsWithTag("DarkColor");
        mediumColoredObjects = GameObject.FindGameObjectsWithTag("MediumColor");
        lightColoredObjects = GameObject.FindGameObjectsWithTag("LightColor");
    }

    // UPDATE
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            colorswap.Play();

            if (isEnvironmentColored)
            {
                paintBW();
                // Set the environment color to b&w
                isEnvironmentColored = false;
            }
            else
            {
                paintColor();
                isEnvironmentColored = true;
            }
        }
    }

    private void paintBW()
    {
        // Change the color of the objects
        foreach (GameObject darkObject in darkColoredObjects)
        {
            darkObject.GetComponent<SpriteRenderer>().color = Color.black;
        }

        foreach (GameObject mediumObject in mediumColoredObjects)
        {
            mediumObject.GetComponent<SpriteRenderer>().color = Color.grey;
        }

        foreach (GameObject lightObject in lightColoredObjects)
        {
            lightObject.GetComponent<SpriteRenderer>().color = Color.white;
            lightObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void paintColor()
    {
        // Change back the color of the objects
        foreach (GameObject darkObject in darkColoredObjects)
        {
            darkObject.GetComponent<SpriteRenderer>().color= darkBlue;
        }

        foreach (GameObject mediumObject in mediumColoredObjects)
        {
            mediumObject.GetComponent<SpriteRenderer>().color = mediumBlue;
        }

        foreach (GameObject lightObject in lightColoredObjects)
        {
            lightObject.GetComponent<SpriteRenderer>().color = lightBlue;
            lightObject.GetComponent<BoxCollider2D>().enabled = true;
            
        }
    }
}
