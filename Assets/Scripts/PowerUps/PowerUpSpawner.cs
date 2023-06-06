using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private int maxPowerUps = 5;
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private float minX = -6f;
    [SerializeField] private float minY = -6f;
    [SerializeField] private float maxX = 6f;
    [SerializeField] private float maxY = 6f;
    [SerializeField] private GameObject[] powerUpPrefabs;

    private List<GameObject> currentPowerUps = new();
    private List<GameObject> temp = new();
    private Vector2 randomPosition;
    private int randomIndex = 0;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 0f, spawnDelay);
    }

    private void SpawnPowerUp()
    {
        if (currentPowerUps.Count >= maxPowerUps)
        {
            return;
        }

        randomPosition = GenerateRandomPosition();
        randomIndex = Random.Range(0, powerUpPrefabs.Length);

        currentPowerUps.Add(Instantiate(powerUpPrefabs[randomIndex], randomPosition, Quaternion.identity));
        if (currentPowerUps.Count < maxPowerUps)
        {
            CheckPowerUps();
        }
    }

    private Vector2 GenerateRandomPosition()
    {
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);
        return new Vector2(x, y);
    }

    private void CheckPowerUps()
    {
        foreach (var item in currentPowerUps)
        {
            if (item != null)
            {
                temp.Add(item);
            }
        }
        currentPowerUps.Clear();
        if (temp.Count > 0)
        {
            currentPowerUps.AddRange(temp);
        }
        temp.Clear();
    }
}