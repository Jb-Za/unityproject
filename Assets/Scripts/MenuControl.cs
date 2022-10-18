using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{   
    public void startButton()
    {
        SceneManager.LoadScene("SpawnScene"); //loads "SpawnScene" (SceneManager.GetActiveScene().buildindex + 1)
    }
    public void quitButton()
    {
        Application.Quit();
    }
}
