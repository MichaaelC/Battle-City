using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int spawnLimit;
    public EnemySpawn[] enemySpawn;
    public GameObject levelCompleteUI;

    public void Start()
    {
        StartSpawn();
    }

    public void StartSpawn()
    {
        foreach (var item in enemySpawn)
        {
            item.StartSpawning();
        }
    }
    private void Update()
    {
        if (spawnLimit <=0 && CheckSpawnsIfFinished())
        {
            levelCompleteUI.SetActive(true);
        }
        else if(spawnLimit <= 0)
        {
            foreach(var item in enemySpawn)
            {
                item.StopSpawning();
            }          
        }
    }

    private bool CheckSpawnsIfFinished()
    {
        bool value = true;
        for (int i = 0; i < enemySpawn.Length; i++)
        {
            if (!enemySpawn[i].isEmpty())
            {
                value = false;
            }
        }
        return value;
    }
}
