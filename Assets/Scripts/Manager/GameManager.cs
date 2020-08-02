using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(1);
    }
}
