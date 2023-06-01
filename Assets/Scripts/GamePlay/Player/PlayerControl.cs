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
        //has reference in input system
        ui.ShowPauseMenu();
    }
}