using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restitution : MonoBehaviour
{
	public float restitution, bounceLimit, boundsLimit, groundHeight;

	public Vector3 velocity, acceleration;
    public VectorLib vecLib;

    bool CheckBounce(float height) // Checks if the ball is touching the ground.
    {
	    if (transform.position.y - transform.lossyScale.y / 2 < height)
	    {
			Debug.Log("Is touching ground.");
		    return true;
	    }

	    return false;
    }

    void ResetHeight() // Resets height to make bounces more consistent.
    {
	    Vector3 tempVector = transform.position;
	    tempVector.y = groundHeight + (transform.lossyScale.y / 2);
	    transform.position = tempVector;
    }

    void Bounce() // Bounce function to add velocity to the ball when its on the ground. TODO Needs some work on the bounce limit! / Bounce Height
	{
	    float newVelocity = Math.Abs(velocity.y) * restitution; // Would not work if the ball bounced off of a ceiling!
		ResetHeight();
	    if (Math.Abs(velocity.y) > bounceLimit)
	    {
		    Debug.Log("Ball Velocity was: " + velocity.y);
		    velocity.y = newVelocity;
		    Debug.Log("Bounce Velocity was: " + newVelocity);
		    return;
	    }
	    velocity.y = 0;
    }

    void FreezeBall() // Sets the velocity vector to zero, in turn nulling it's velocity.
    {
	    velocity = vecLib.ZeroVec();
		Debug.Log("Ball Frozen.");
    }

    bool CheckBounds() // Checks if the ball is outside the horizontal bounds.
    {
	    if (transform.position.x < -boundsLimit || transform.position.x > boundsLimit || transform.position.z < -boundsLimit || transform.position.z > boundsLimit)
	    {
			Debug.Log("Out of Bounds.");
		    return true;
	    }
	    return false;
    }

    // Update is called once per frame
    void Update()
    {
	    velocity = vecLib.AddVec(velocity, vecLib.ScalarMultVec(acceleration, Time.deltaTime)); // Adds acceleration to the velocity.
	    if (CheckBounce(groundHeight)) { Bounce(); }
	    if (CheckBounds()) { FreezeBall(); }
		transform.position = vecLib.AddVec(transform.position, vecLib.ScalarMultVec(velocity, Time.deltaTime));
		
	}
}
