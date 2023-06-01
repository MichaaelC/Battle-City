using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private InGameUI ui;

    private void Start()
    {
        ui = FindObjectOfType<InGameUI>();
    }

    private void OnMenu()
    {
        ui.ShowPauseMenu();
    }
}
