using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**=====================================
Class StateManager
---------------------
Description

Manage the transitions between the scene or the restart of the level
--------------------------
Author(s):
Bryan Curchod
======================================*/
public class StateManager : MonoBehaviour
{
    public void ReloadCurrentScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ChangeSceneByName(string name){
        if(name != null){
            // Debug.Log("transition to the scene \"" + name + "\"");
            SceneManager.LoadScene(name);
        }
    }

}
