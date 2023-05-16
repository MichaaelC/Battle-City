using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteMenu : MonoBehaviour
{
    
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("dfdasdf");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
        //Debug.Log("dfdasdf");
    }
}
