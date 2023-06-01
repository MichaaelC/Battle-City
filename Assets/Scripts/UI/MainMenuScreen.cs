using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private int level = 1;
    [SerializeField] private int maxLevel = 50;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Awake()
    {
        level = 1;
    }

    public void SelectNextLevel()
    {
        level++;
        if(level > maxLevel)
            level = maxLevel;
        levelText.text = level.ToString();
        
    }

    public void SelectPrevLevel()
    {
        level--;
        if (level < 1)
            level = 1;
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
