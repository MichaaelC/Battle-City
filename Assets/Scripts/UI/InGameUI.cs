using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject levelComplete;

    public void ShowGameOverScreen()
    {
        gameOver.SetActive(true);
    }

    public void ShowContinueGameScreen()
    {
        levelComplete.SetActive(true);
    }

    public static void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void RestartGameButton()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

    public static void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
