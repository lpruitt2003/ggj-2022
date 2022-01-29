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

    public void ToggleDeathPanel(){
        deathPanel.SetActive(!deathPanel.activeSelf);
    }

    public void ToggleWinPanel(){
        winPanel.SetActive(!winPanel.activeSelf);
    }
}
