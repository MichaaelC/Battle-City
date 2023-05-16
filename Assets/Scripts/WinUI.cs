using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinUI : MonoBehaviour
{
    public ContinueGameMenu _continueGameMenu;

    public void ContinueGameScreen(bool value)
    {
        _continueGameMenu.ShowContinueGameScreen(value);
    }
}
