using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/**=====================================
Class AudioManager
---------------------
Description:

Manages the muting / activating music or sound.
--------------------------
Author(s):
Selin Kaya
======================================*/
public class AudioManager : MonoBehaviour
{
    public StudioEventEmitter music;
    public GameObject sound;

    // Have only one AudioPlayer at each scene, destroy object if it is more than one
    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("AudioPlayer");
        if (objs.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        music.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void muteMusic()
    {
        music.Stop();
    }

    public void playMusic()
    {
        music.Play();
    }

    public void muteSound()
    {
        sound.SetActive(false);
    }

    public void activateSound()
    {
        sound.SetActive(true);
    }
}
