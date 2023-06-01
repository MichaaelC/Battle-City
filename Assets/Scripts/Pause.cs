using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private static bool isPause = false;

    private void OnEnable()
    {
        PauseGame();    
    }

    private void OnDisable()
    {
        PauseGame();
    }

    public void PauseGame()
    {
       if(!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
        }
    }
}
