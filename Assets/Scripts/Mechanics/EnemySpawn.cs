using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int spawnLimit = 5;
    [SerializeField] private float spawnTimer = 0f;
    [SerializeField] private bool isStart = false;
    [SerializeField] private List<GameObject> spawnCount;

    private WaitForSeconds spawnDelay;
    private LevelManager spawnLevel;
    private List<EnemyMoveAI> temp = new();

    private bool isSpawning = false;

    private void Awake()
    {
        spawnDelay = new WaitForSeconds(spawnTimer);
        spawnLevel =  GetComponentInParent<LevelManager>();
    }

    private void Update()
    {
        if (isStart)
        {
            if (spawnCount.Count <= spawnLimit && !isSpawning)
            {
                StartCoroutine(Spawn());
            }  
        }
        // To detect if spawn count is clear
        temp.Clear();
        temp = GetComponentsInChildren<EnemyMoveAI>().ToList();
        spawnCount.Clear();

        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i] != null)
            {
                spawnCount.Add(temp[i].gameObject);
            }
        }
    }

    public IEnumerator Spawn()
    {
        isSpawning = true;

        SpawnEnemy();
        yield return spawnDelay;
        isSpawning = false;
    }

    public void SpawnEnemy()
    {
        if(spawnCount.Count <= spawnLimit)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, this.transform.position, this.transform.rotation);
            newEnemy.transform.parent = transform;
            spawnLevel.spawnLimit--;
        }
        
    }
    public void StartSpawning()
    {
        isStart = true;
    }
    public void StopSpawning()
    {
        isStart = false;
    }

    public bool IsEmpty()
    {
        if (spawnCount.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
