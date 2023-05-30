using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpType
{
    IncreaseSpeed,
    EnemyDestroy
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;
    public float powerUpDuration = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            ApplyPowerUpEffect(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void ApplyPowerUpEffect(GameObject player)
    {
        //PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
        EnemyMoveAI[] enemies;
        //EnemySpawn[] enemySpawns;
        switch (powerUpType)
        {
            case PowerUpType.EnemyDestroy:
                Debug.Log("destroyed");
                enemies = FindObjectsOfType<EnemyMoveAI>();
                foreach (EnemyMoveAI enemy in enemies)
                {
                    enemy.DestroyEnemy();
                }
                break;
        }
    }
}
            /*case PowerUpType.EnemyFreeze:
                enemies = FindObjectsOfType<AI>();
                enemySpawns = FindObjectsOfType<EnemySpawn>();
                Dictionary<AI, bool> originalEnemyStates = new Dictionary<AI, bool>();
                Dictionary<EnemySpawn, bool> originalSpawnStates = new Dictionary<EnemySpawn, bool>();
                foreach (AI enemy in enemies)
                {
                    originalEnemyStates[enemy] = enemy.enabled;
                    enemy.enabled = false;
                    
                }
                foreach(EnemySpawn spawn in enemySpawns)
                {
                    originalSpawnStates[spawn] = spawn.enabled;
                    spawn.enabled = false;
                }   
                StartCoroutine(RevertEnemyFreeze(enemies, enemySpawns, originalEnemyStates, originalSpawnStates));
                break;
        }
        gameObject.SetActive(false);*/
    
   
    /*private IEnumerator RevertEnemyFreeze(AI[] enemies, EnemySpawn[] enemySpawns, 
        Dictionary<AI, bool> originalEnemyStates, Dictionary<EnemySpawn, bool> originalSpawnStates)
    {
        yield return new WaitForSeconds(5f);
        foreach(AI enemy in enemies)
        {
            if (originalEnemyStates.ContainsKey(enemy))
            {
                enemy.enabled = originalEnemyStates[enemy];
            }
        }

        foreach(EnemySpawn spawn in enemySpawns)
        {
            if (originalSpawnStates.ContainsKey(spawn))
            {
                spawn.enabled = originalSpawnStates[spawn];
            }
        }
    }*/

