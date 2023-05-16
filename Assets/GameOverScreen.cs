using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Screen : MonoBehaviour
{
    public void EnterGame()
    {
        SceneManager.LoadScene("SampleScene");
    }   
}
