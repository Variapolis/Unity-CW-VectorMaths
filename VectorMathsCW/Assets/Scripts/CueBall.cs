using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    public float mass, friction, minVelocity;

	public Vector3 velocity;
	public VectorLib vecLib;
	public  CueBall[] balls;
	public WallToLine[] walls;

	void FrictionToleranceHandler() // If velocity is below a certain speed, sets to 0.
    {
	    if (velocity.x < minVelocity && velocity.x > -minVelocity)
	    {
		    velocity.x = 0;
	    }
	    if (velocity.z < minVelocity && velocity.z > -minVelocity)
	    {
		    velocity.z = 0;
	    }
		// Alternate method could also check the magnitude, if below a certain threshold, ScalarMult entire Vector by 0.
	}

    void WallCollisionHandler(WallToLine wall)
    {
		Debug.Log("WallColFunc");
	    if (wall.transform.rotation.y == 0 || wall.transform.rotation.y == 180) // Axis Aligned checking wall
		{
			if (Mathf.Sign(wall.transform.position.z) == Mathf.Sign(velocity.z)) 
				// if velocity sign is the same as the position sign of the wall, cheap way to check "Is Moving Towards"
			{
				Debug.Log("Reflected Z axis");
				velocity = vecLib.ReflVecAxisAlign(velocity, 'z'); 
			}
			
		}
		else
		{
			if (Mathf.Sign(wall.transform.position.x) == Mathf.Sign(velocity.x))
			{
				Debug.Log("Reflected X axis");
				velocity = vecLib.ReflVecAxisAlign(velocity, 'x');
			}
		}
    }

    void BallCollisionHandler(CueBall ball2) // TODO refer to video for comments
    {
	    
	    float velocityScalar = vecLib.DotVec(vecLib.SubVec(velocity, ball2.velocity), vecLib.SubVec(transform.position, ball2.transform.position)) / Mathf.Pow(vecLib.MagVec(vecLib.SubVec(transform.position, ball2.transform.position)), 2f);
	    float massCalc = velocityScalar * (2 * ball2.mass) / mass + ball2.mass;
	    velocity = vecLib.SubVec(velocity, vecLib.ScalarMultVec(vecLib.SubVec(transform.position, ball2.transform.position), massCalc));
    }


    // Update is called once per frame
    void Update()
    {
	    foreach (WallToLine i in walls) // iterates through the walls array and checks collision against every wall.
	    {
		    bool onLine = (vecLib.isOnLine(transform.position, i.position1, i.position2,
			    transform.localScale.x / 2 + i.transform.localScale.z / 2));
		    if (onLine)
		    {
			    WallCollisionHandler(i);
			}
	    }

	    foreach (CueBall i in balls) // iterates through the balls and checks collision
	    {
		    bool ballCol = (vecLib.checkSphereCol(transform.position, i.transform.position, transform.localScale.x / 2,
			    i.transform.localScale.x / 2));
			// if this ball or the other ball is moving towards the other, and the ball is colliding, runs ball col handler
		    if (ballCol && (vecLib.isMovingTowards(i.transform.position, transform.position, velocity) || vecLib.isMovingTowards(transform.position, i.transform.position, i.velocity)))
		    {
			    BallCollisionHandler(i);
		    }
	    }

		// Friction
		velocity = vecLib.AddVec(velocity, vecLib.ScalarMultVec(velocity, -friction * Time.deltaTime)); // velocity is added to itself multiplied by negative friction
		FrictionToleranceHandler();

		// Velocity transform
		transform.position = vecLib.AddVec(transform.position, vecLib.ScalarMultVec(velocity, Time.deltaTime)); // velocity added to position over time

	}

}
