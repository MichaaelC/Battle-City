using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool isEnabled = false;
    public int playerLives = 3;
    public int spawnLimit = 20;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject playerBase;
    [SerializeField] private InGameUI ui;
    [SerializeField] private EnemySpawn[] enemySpawn;

    private PlayerSpawn playerSpawn;

    private void Start()
    {
        isEnabled = true;
        playerSpawn = FindObjectOfType<PlayerSpawn>();
        playerBase = FindObjectOfType<HealthBase>().gameObject;
        player = playerSpawn.GetPlayer();
        enemySpawn = GetComponentsInChildren<EnemySpawn>();
        ui = GetComponentInChildren<InGameUI>();
        StartSpawn();
    }

    private void FixedUpdate()
    {
        CheckPlayerLives();
        CheckIfSpawnsAreFinished();
        CheckIfBaseIsAlive();
    }

    private void CheckIfBaseIsAlive()
    {
        if (playerBase == null)
        {
            GameOver();
        }
    }

    private void CheckPlayerLives()
    {
        if (playerSpawn.GetPlayer() == null)
        {
            if (playerLives > 0)
            {
                playerLives--;
                playerSpawn.SpawnPlayer();
                player = playerSpawn.GetPlayer();
            }
            else if (playerLives == 0)
            {
                playerLives--;
                playerSpawn.SpawnPlayer();
                player = playerSpawn.GetPlayer();
                playerSpawn.isEnabled = false;
            }
            else if (playerLives < 0)
            {
                GameOver();
            }
        }
    }

    private void CheckIfSpawnsAreFinished()
    {
        if (spawnLimit <= 0 && CheckSpawnsIfFinished())
        {
            ui.ShowContinueGameScreen();
        }
        else if (spawnLimit <= 0)
        {
            foreach (var item in enemySpawn)
            {
                item.StopSpawning();
            }
        }
    }

    public void StartSpawn()
    {
        foreach (var item in enemySpawn)
        {
            item.StartSpawning();
        }
    }

    private bool CheckSpawnsIfFinished()
    {
        bool value = true;
        for (int i = 0; i < enemySpawn.Length; i++)
        {
            if (!enemySpawn[i].IsEmpty())
            {
                value = false;
            }
        }
        return value;
    }

    private void GameOver()
    {
        ui.ShowGameOverScreen();
    }
}