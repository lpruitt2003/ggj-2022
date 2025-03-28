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

    // Bool that will check the state of the environment
    public bool isEnvironmentColored;

    //Sound effects
    public StudioEventEmitter colorswap;

    // Background sprites
    public Sprite coloredBackground;
    public Sprite bwBackground;

    // For holding the colored objects inside the level
    private GameObject[] darkColoredObjects;
    private GameObject[] mediumColoredObjects;
    private GameObject[] lightColoredObjects;
    private GameObject[] squareObjects;
    private GameObject[] backgrounds;

    // START
    // - Will fetch the colored objects according to their tags
    void Start()
    {
        isEnvironmentColored = true;

        darkColoredObjects = GameObject.FindGameObjectsWithTag("DarkColor");
        mediumColoredObjects = GameObject.FindGameObjectsWithTag("MediumColor");
        lightColoredObjects = GameObject.FindGameObjectsWithTag("LightColor");
        squareObjects = GameObject.FindGameObjectsWithTag("Square");
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }

    // UPDATE
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerControls.isAlive)
        {
            colorswap.Play();
            // player 1 swaps the color to BW and player 2 swaps it back to color
            // checks what the tag of the component is
            
            if (isEnvironmentColored)
            {
                paintBW();
                isEnvironmentColored = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.O) && Player2Controls.isAlive)
        {
            colorswap.Play();
            if (!isEnvironmentColored)
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
            lightObject.SetActive(false);
        }

        foreach (GameObject square in squareObjects)
        {
            square.GetComponent<SpriteRenderer>().color = Color.black;
        }

        foreach (GameObject background in backgrounds)
        {
            background.GetComponent<SpriteRenderer>().sprite = bwBackground;
        }
    }

    private void paintColor()
    {
        // Change back the color of the objects
        foreach (GameObject darkObject in darkColoredObjects)
        {
            darkObject.GetComponent<SpriteRenderer>().color= Color.white;
        }

        foreach (GameObject mediumObject in mediumColoredObjects)
        {
            mediumObject.GetComponent<SpriteRenderer>().color = Color.white;
        }

        foreach (GameObject lightObject in lightColoredObjects)
        {
            lightObject.SetActive(true);
        }

        foreach (GameObject square in squareObjects)
        {
            square.GetComponent<SpriteRenderer>().color = darkBlue;
        }

        foreach (GameObject background in backgrounds)
        {
            background.GetComponent<SpriteRenderer>().sprite = coloredBackground;
        }
    }
}
