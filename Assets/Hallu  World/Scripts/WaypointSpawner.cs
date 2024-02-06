using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public List<Transform> waypoints;
    public float movementSpeed = 5f;
    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 2f;

    private GameObject spawnedObject;

    private void Start()
    {
        StartCoroutine(SpawnObjectRepeatedly());
    }

    private IEnumerator SpawnObjectRepeatedly()
    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));
        }
    }

    private void SpawnObject()
    {
        spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        spawnedObject.GetComponent<EnemyFollowPoints>().SetWaypoints(waypoints);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Count; i++)
        {
            Gizmos.DrawSphere(waypoints[i].position, 0.2f);
        }
    }
}
