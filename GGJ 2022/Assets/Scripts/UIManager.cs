using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**=====================================
Class UIManager
-------------------------
Description:

Manage the different UI panel in the game
    - Death screen
    - Victory screen
    - HUD (TODO)
--------------------------
Author(s):
Bryan Curchod
=====================================*/
public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathPanel;
    [SerializeField] GameObject winPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject optionPanel;

    public void ToggleDeathPanel(){
        deathPanel.SetActive(!deathPanel.activeSelf);
    }

    public void ToggleWinPanel(){
        winPanel.SetActive(!winPanel.activeSelf);
    }
    public void TogglePausePanel(){
        pausePanel.SetActive(!pausePanel.activeSelf);
    }

    public void ToggleOptionPanel(){
        // need to 
        optionPanel.SetActive(!optionPanel.activeSelf);
        TogglePausePanel();
    }

    public bool isOptionsPanelOpen(){
        return optionPanel.activeSelf;
    }
}
