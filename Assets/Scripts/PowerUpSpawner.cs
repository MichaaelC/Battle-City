using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] powerUpPrefabs;
    public int maxPowerUps = 5;
    public float spawnDelay;
    public float minX = -6;
    public float maxX = 6;
    public float minY = -6;
    public float maxY = 6;
    private int currentPowerUps = 0;

    private List<Vector2> usedPosition = new List<Vector2>();
    private void Start()
    {
        InvokeRepeating("SpawnPowerUp", 0f, spawnDelay);
    }

    void SpawnPowerUp()
    {
        if(currentPowerUps >= maxPowerUps)
        {
            return;
        }
        Vector2 randomPosition = GenerateRandomPosition();

        while (usedPosition.Contains(randomPosition))
        {
            randomPosition = GenerateRandomPosition();
        }
        int randomIndex = Random.Range(0, powerUpPrefabs.Length);
        GameObject randomPowerUpPrefab = powerUpPrefabs[randomIndex];
        Instantiate(randomPowerUpPrefab, randomPosition, Quaternion.identity);

        usedPosition.Add(randomPosition);
        currentPowerUps++;
    }

    Vector2 GenerateRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        return new Vector2(x, y);
    }

    public void PowerUpCollected(Vector2 position)
    {
        currentPowerUps--;
        usedPosition.Remove(position);
    }
}
