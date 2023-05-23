using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    public GameOverMenu gameOver;

    public void GameOverScreen(bool value)
    {
        gameOver.ShowGameOverMenu(value);
    }
}
