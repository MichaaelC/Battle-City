using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerBase;
    public PlayerSpawn playerSpawn;
    public int playerLives = 3;
    public bool isSpawnerDone = false;
    public bool isEnabled = false;

    private WaitForSeconds wait;
    private float waitTime = 0.2f;

    void Start()
    {
        isEnabled = true;
        wait = new(waitTime);
        playerSpawn = FindObjectOfType<PlayerSpawn>();
        playerBase = FindObjectOfType<HealthBase>().gameObject;
        player = playerSpawn.player;
        //StartCoroutine(ScanState());
    }

    private void Update()
    {
        if (playerSpawn.player == null)
        {
            if(playerLives > 0)
            {
                playerLives--;
                playerSpawn.SpawnPlayer();
            }
            else if(playerLives == 0)
            {
                playerLives--;
                playerSpawn.SpawnPlayer();
                playerSpawn.isEnabled = false;
            }
            else if(playerLives < 0)
            {
                InGameUI ui = FindObjectOfType<InGameUI>();
                ui.GameOverScreen(true);
            }
        }
    }
}
