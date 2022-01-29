using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**=====================================
Class LevelManager
--------------------------
Description:

Manage the death and victory mechanic in the level
--------------------------
Author(s):
Bryan Curchod
=====================================*/
public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake(){
        if(LevelManager.instance == null){
            instance = this;
        }
        else {
            Destroy(gameObject);
        }
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    public void GameOver(){
        UIManager _ui = GetComponent<UIManager>();
        if(_ui != null){
            _ui.ToggleDeathPanel();
        }
    }

    public void Victory(){
        UIManager _ui = GetComponent<UIManager>();

        if(_ui != null){
            _ui.ToggleWinPanel();
        }
    }

    public void PauseMenu(){
        UIManager _ui = GetComponent<UIManager>();

        if(_ui != null){
            _ui.TogglePausePanel();
            Time.timeScale = Time.timeScale == 0? 1: 0;
        }
    }
}
