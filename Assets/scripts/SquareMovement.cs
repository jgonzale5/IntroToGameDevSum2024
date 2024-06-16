//Jing Dai
//Square Movement
//June 2 2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMovement : MonoBehaviour //monobehavior so it can be attached to square
{
    public float speed = 5f;
    private Vector3[] waypoints;
    private int currentWaypointIndex = 0;
    void Start()
    {
        waypoints = new Vector3[]
        {
            new Vector3(2, 2, 0),
            new Vector3(2, -2, 0),
            new Vector3(-2, -2, 0),
            new Vector3(-2, 2, 0)
        };
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex], speed * Time.deltaTime);
        if (transform.position == waypoints[currentWaypointIndex])
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}
