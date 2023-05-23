using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void ShowGameOverMenu(bool value)
    {
        this.gameObject.SetActive(value);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }

    public void RestartGameButton()
    {
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }
}
