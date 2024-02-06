using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPoints : MonoBehaviour
{
    public float movementSpeedMin = 1f;
    public float movementSpeedMax = 5f;
    public float waypointReachedThreshold = 0.1f;
    public List<Transform> waypoints = new();

    Transform targetWaypoint;
    Vector2 direction;
    private float movementSpeed = 0f;
    private int currentWaypointIndex = 0;

    private void Awake()
    {
        movementSpeed = Random.Range(movementSpeedMin, movementSpeedMax);
    }
    public void SetWaypoints(List<Transform> waypoints)
    {
        this.waypoints.AddRange(waypoints);
    }

    private void Update()
    {
        if (waypoints.Count > 0)
        {
            targetWaypoint = waypoints[currentWaypointIndex];
            direction = (Vector2)targetWaypoint.position - (Vector2)transform.position;
            transform.Translate(direction.normalized * movementSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, targetWaypoint.position) < waypointReachedThreshold)
            {
                waypoints.Remove(targetWaypoint);

                if (waypoints.Count == 0)
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
