using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public float spawnDelay = 5f;
    public Transform playerSpawnPoint;



    private void Start()
    {
        Invoke("SpawnPlayer", spawnDelay);
    }

    void SpawnPlayer()
    {
        GameObject newPlayer = Instantiate(playerPrefab, playerSpawnPoint.position, playerSpawnPoint.rotation);
        newPlayer.transform.parent = transform;
    }

   
}
