using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{

	public VectorLib vecLib;
	public int startingWaypoint;
	public float speed;
	public float distanceThreshold;

	public GameObject[] waypoints;
    private int waypointIterator;
    private float distance;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
	    waypointIterator = startingWaypoint;
        Debug.Log(waypoints.Length);
        if (waypointIterator > waypoints.Length - 1) { waypointIterator = 0; } // Sets up initial waypoint to not be out of range.
    }

    float GetDistance(Vector3 vec1)
    {
	    return vecLib.MagVec(vecLib.SubVec(transform.position, vec1)); // subtracts own position vec from waypoint vec and gets magnitude to get distance
    }

    // Update is called once per frame
    void Update()
    {
        // Sets the velocity to a scalar multiple of the Direction Vector between the waypoint and own position by a multiple of speed and  time.
	    velocity = 
		    vecLib.ScalarMultVec(vecLib.UnitDirVec(waypoints[waypointIterator].transform.position, transform.position), speed * Time.deltaTime);
	    transform.position = vecLib.AddVec(transform.position, velocity); // Position changes based on velocity towards next waypoint.
	    distance = GetDistance(waypoints[waypointIterator].transform.position); // Finds distance and checks whether within threshold to iterate to next waypoint.
	    if (distance < distanceThreshold) { waypointIterator++; }
	    if (waypointIterator > waypoints.Length - 1) { waypointIterator = 0; }
    }
}
