using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // TODO "to menu" option to define
    [SerializeField] GameObject deathPanel;

    public void ToggleDeathPanel(){
        deathPanel.SetActive(!deathPanel.activeSelf);
    }
}
