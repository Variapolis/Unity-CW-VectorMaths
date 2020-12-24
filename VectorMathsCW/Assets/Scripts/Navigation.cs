using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{

	public VectorLib vectorLibrary;
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
        if (waypointIterator > waypoints.Length - 1) { waypointIterator = 0; }
    }

    float GetDistance(Vector3 vec1)
    {
	    return vectorLibrary.MagVec(vectorLibrary.SubVec(transform.position, vec1));
    }

    // Update is called once per frame
    void Update()
    {
	    velocity = 
		    vectorLibrary.ScalarMultVec(vectorLibrary.UnitDirVec(waypoints[waypointIterator].transform.position, transform.position), speed * Time.deltaTime);
	    transform.position = vectorLibrary.AddVec(transform.position, velocity);
	    distance = GetDistance(waypoints[waypointIterator].transform.position);
	    if (distance < distanceThreshold) { waypointIterator++; }
	    if (waypointIterator > waypoints.Length - 1) { waypointIterator = 0; }
    }
}
