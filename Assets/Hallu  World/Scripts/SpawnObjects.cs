using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnIntervalMin = 1f;
    public float spawnIntervalMax = 3f;
    private float spawnInterval = 1f;

    private Coroutine spawnCoroutine;

    private void Start()
    {
        StartSpawning();
    }

    private void StartSpawning()
    {
        if (spawnCoroutine != null)
            StopCoroutine(spawnCoroutine);

        spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }

    private void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            SpawnObject();
            spawnInterval = Random.Range(spawnIntervalMin, spawnIntervalMax);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnObject()
    {
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);
    }
}
