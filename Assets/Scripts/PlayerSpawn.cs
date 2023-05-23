using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject player;
    public float spawnDelay = 5f;
    public bool isEnabled = true;

    private void Start()
    {
    }

    private void Update()
    {
        /*
        if (player == null && isEnabled)
        {
            Debug.Log("Spawned object was destroyed!");

            SpawnPlayer();
        }
        */
    }

    public void SpawnPlayer()
    {
        if (isEnabled)
        {
            player  = Instantiate(playerPrefab, transform.position, transform.rotation);
            player.transform.parent = transform;
        }
    }

   
}
