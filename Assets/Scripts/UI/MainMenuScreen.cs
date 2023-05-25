using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject levelMenu;
    public int level = 1;
    public TextMeshProUGUI levelText;

    private void Awake()
    {
        level = 1;
    }

    public void SelectNextLevel()
    {
        level++;
        levelText.text = level.ToString();
        
    }

    public void SelectPrevLevel()
    {
        level--;
        levelText.text = level.ToString();
  
    }

    public void EnterGame()
    {
        SceneManager.LoadScene("SampleScene " + level);
    }


    public void ToLevelMenu()
    {
        startMenu.SetActive(false);
        levelMenu.SetActive(true);
    }


    public void ToStartMenu()
    {
        startMenu.SetActive(true);
        levelMenu.SetActive(false);
    }



    public void OnApplicationQuit()
    {
        Debug.Log("quit");
        Application.Quit();
    }
}
