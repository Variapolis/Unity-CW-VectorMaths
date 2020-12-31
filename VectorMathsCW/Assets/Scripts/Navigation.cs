using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Animations;

public class Navigation : MonoBehaviour
{

	public VectorLib vecLib;
	public int startingWaypoint;
	public float speed;
	public float distanceThreshold;

	public GameObject[] waypoints;
    private int waypointIterator;
    private float distance, startAngle;
    private Vector3 velocity, polar;
    private bool rotating;
    private float counter;
    private float poleThreshold = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
	    rotating = false;
	    waypointIterator = startingWaypoint;
        Debug.Log(waypoints.Length);
        if (waypointIterator >= waypoints.Length ) { waypointIterator = 0; } // Sets up initial waypoint to not be out of range.
		CheckCollision();
    }

    float GetDistance(Vector3 vec1)
    {
	    return vecLib.MagVec(vecLib.SubVec(transform.position, vec1)); // subtracts own position vec from waypoint vec and gets magnitude to get distance
    }

    void MoveTowards(Vector3 target)
    {
	    velocity =
		    vecLib.ScalarMultVec(vecLib.UnitDirVec(target, transform.position), speed * Time.deltaTime);
	    transform.position = vecLib.AddVec(transform.position, velocity); // Position changes based on velocity towards next waypoint.
    }

    void CheckCollision()
    {
	    distance = GetDistance(waypoints[waypointIterator].transform.position); // Finds distance and checks whether within threshold to iterate to next waypoint.
	    if (distance < distanceThreshold)
	    {
		    polar = vecLib.ToSphericalPolar(vecLib.SubVec(transform.position, waypoints[waypointIterator].transform.position));
		    startAngle = polar.z;
			rotating = true;
	    }
    }

    void Rotate()
    {
		Debug.Log("distance good");
	    polar.z += speed * Time.deltaTime;
		transform.position = vecLib.AddVec(waypoints[waypointIterator].transform.position, vecLib.ToSphericalCartes(polar));
		if (polar.z > startAngle + Mathf.PI * 2 - poleThreshold && polar.z < startAngle + Mathf.PI * 2 + poleThreshold) { Iterate(); }
    }

    void Iterate()
    {
	    waypointIterator++;
	    if (waypointIterator >= waypoints.Length) { waypointIterator = 0; }
	    rotating = false;
    }



    // Update is called once per frame
    void Update()
    {
	    if (!rotating)
	    {
		    // Sets the velocity to a scalar multiple of the Direction Vector between the waypoint and own position by a multiple of speed and  time.
		    MoveTowards(waypoints[waypointIterator].transform.position);
		    CheckCollision();
	    }
	    else
	    {
		    Rotate();
	    }

    }
}
