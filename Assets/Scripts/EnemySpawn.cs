using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    //public float spawnDelay = 5f;
    public Transform spawnPoint;
    [SerializeField]
    
    private bool isStart = false;
    public float spawnTimer = 0f;

    public int spawnLimit = 2;
    private bool isSpawning = false;
    public List<GameObject> spawnCount;
    private WaitForSeconds spawnDelay;
    private Level spawnLevel;
    public List<AI> temp;

    private void Awake()
    {
        spawnDelay = new WaitForSeconds(spawnTimer);
        spawnLevel =  GetComponentInParent<Level>();

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
        //Wag idelete mamamatay ka
        temp.Clear();
        temp = GetComponentsInChildren<AI>().ToList();
        spawnCount.Clear();

        for (int i = 0; i < temp.Count; i++)
        {
            if (temp[i] != null)
            {
                spawnCount.Add(temp[i].gameObject);
            }
        }
        //
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
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
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

    public bool isEmpty()
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
