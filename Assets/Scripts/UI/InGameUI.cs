using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject controls;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject levelComplete;
    [SerializeField] private GameObject pauseMenu;

    public void ShowGameOverScreen()
    {
        gameOver.SetActive(true);
    }

    public void ShowContinueGameScreen()
    {
        levelComplete.SetActive(true);
    }

    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
        HideControls();
    }

    public void HidePauseMenu()
    {
        //has reference in resume button in pause menu game object
        pauseMenu.SetActive(false);
        ShowControls();
    }

    public void ShowControls()
    {
        controls.SetActive(true);
    }

    public void HideControls()
    {
        controls.SetActive(false);
    }

    public static void NextLevel()
    {
        //has reference in resume button in ui gameobject
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public static void RestartGameButton()
    {
        //has reference in resume button in ui gameobject
        string scene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(scene);
    }

    public static void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}