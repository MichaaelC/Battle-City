using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueGameMenu : MonoBehaviour
{
    public void ShowContinueGameScreen(bool value)
    {
        this.gameObject.SetActive(value);
    }

    public void ContinueGameButton()
    {
        SceneManager.LoadScene("Level2");
    }

    public void QuitGameButton()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
