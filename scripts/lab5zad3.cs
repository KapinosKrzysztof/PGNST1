using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformWaypoints : MonoBehaviour
{
    public float platformSpeed = 2f; 
    public List<Vector3> waypoints = new List<Vector3>(); 
    private int currentWaypointIndex = 0;
    private bool isReturning = false;

    void Start()
    {
        
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0];
        }
    }

    void Update()
    {
        if (waypoints.Count == 0)
        {
            return; 
        }

    
        Vector3 targetPosition = waypoints[currentWaypointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, platformSpeed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (!isReturning)
            {
                if (currentWaypointIndex < waypoints.Count - 1)
                {
                    currentWaypointIndex++;
                }
                else
                {
                    isReturning = true;
                    currentWaypointIndex--;
                }
            }
            else
            {
                if (currentWaypointIndex > 0)
                {
                    currentWaypointIndex--;
                }
                else
                {
                    isReturning = false;
                    currentWaypointIndex++;
                }
            }
        }
    }
}
    