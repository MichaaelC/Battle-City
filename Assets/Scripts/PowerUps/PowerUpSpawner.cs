using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private float spawnDelay;
    [SerializeField] private int maxPowerUps = 5;
    [SerializeField] private float minX = -6;
    [SerializeField] private float minY = -6;
    [SerializeField] private float maxX = 6;
    [SerializeField] private float maxY = 6;
    [SerializeField] private GameObject[] powerUpPrefabs;
    [SerializeField] private List<GameObject> currentPowerUps;

    private int randomIndex = 0;
    private Vector2 randomPosition;
    private List<GameObject> temp = new();

    private void Start()
    {
        InvokeRepeating(nameof(SpawnPowerUp), 0f, spawnDelay);
    }

    private void SpawnPowerUp()
    {
        CheckPowerUps();
        if (currentPowerUps.Count >= maxPowerUps)
        {
            return;
        }

        randomPosition = GenerateRandomPosition();
        randomIndex = Random.Range(0, powerUpPrefabs.Length);

        currentPowerUps.Add(Instantiate(powerUpPrefabs[randomIndex], randomPosition, Quaternion.identity));
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