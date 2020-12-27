using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    public float friction, minVelocity;

	public Vector3 velocity;
	public VectorLib vecLib;
	public GameObject[] balls, walls;

	private Vector3 _frictionVec;

    // Start is called before the first frame update
    void Start()
    {
	    _frictionVec.x = friction;
	    _frictionVec.z = friction;
    }

    void FrictionToleranceHandler()
    {
	    if (velocity.x < minVelocity)
	    {
		    velocity.x = 0;
	    }
	    if (velocity.z < minVelocity)
	    {
		    velocity.z = 0;
	    }
	}

    // Update is called once per frame
    void Update()
    {
		// Velocity transform
	    transform.position = vecLib.AddVec(transform.position, vecLib.ScalarMultVec(velocity, Time.deltaTime));

		// Friction, not at a 0 to 1 scale. - TODO Make 0 to 1 scale, 1 being completely sticky.
		velocity = vecLib.AddVec(velocity, vecLib.ScalarMultVec(velocity, -friction*Time.deltaTime));

		// Below is the vector reflection and bounds detection. - TODO Turn into separate functions.
		if (transform.position.x > 5 || transform.position.x < -5)
		{
			velocity = vecLib.ReflVecAxisAlign(velocity, 'x');
			if (transform.position.x > 5)
			{
				transform.position = new Vector3(5, transform.position.y, transform.position.z);
			}
			if (transform.position.x < -5)
			{
				transform.position = new Vector3(-5, transform.position.y, transform.position.z);
			}

		}
		if (transform.position.z > 5 || transform.position.z < -5)
		{
			velocity = vecLib.ReflVecAxisAlign(velocity, 'z');
			if (transform.position.z > 5)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, 5);
			}
			if (transform.position.z < -5)
			{
				transform.position = new Vector3(transform.position.x, transform.position.y, -5);
			}
		}

		
		/* 
         TODO Check collision between walls
         TODO Then find the axis of the wall and 

		 DONE use Axis Aligned Reflection Function from the vecLib to reflect the ball accordingly
         DONE Add friction
        
         TODO Part B
        */
    }
}
