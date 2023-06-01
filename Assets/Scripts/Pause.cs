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
        //It produces an error related to input system when clicking the pause button onscreen,
        //but still works fine for now
        if (!isPause)
        {
            isPause = true;
            Time.timeScale = 0;
        }
        else
        {
            isPause = false;
            Time.timeScale = 1;
        }
        Debug.Log("An error log is produced when clicking the pause button onscreen");
    }
}