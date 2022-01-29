using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**=====================================
Class MenuUIManager
---------------------
Description:

Manage the transitions between the menu scenes.

- Main Menu Scene
    - Start Button: Loads the first level.
    - Options Button: Loads the options menu.
    - Quit Button: Exits the game.

- Options Menu Scene
    - Back Button: Goes back to the main menu.
    - Sound Volume Up Button:
    - Sound Volume Down Button:
    - Music Volume Up Button:
    - Music Volume Down Button:
--------------------------
Author(s):
Selin Kaya
======================================*/
public class MenuUIManager : MonoBehaviour
{
    /*
     *  Main Menu =======================================
     */
    // Starts the first level scene
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("1st Level");
    }

    // Load the options menu scene
    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options Menu");
    }

    // Load the options menu scene
    public void QuitGame()
    {
        Application.Quit();
    }


    /*
     *  Options Menu =======================================
     */
    // Loads the main menu scene
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void SoundVolumeUp()
    {
        // TODO: Implement sound volume adjustments
    }

    public void SoundVolumeDown()
    {
        // TODO: Implement sound volume adjustments
    }

    public void MusicVolumeUp()
    {
        // TODO: Implement music volume adjustments
    }

    public void MusicVolumeDown()
    {
        // TODO: Implement music volume adjustments
    }
}
