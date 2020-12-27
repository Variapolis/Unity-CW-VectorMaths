using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBall : MonoBehaviour
{
    public float mass, friction, minVelocity;

	public Vector3 velocity;
	public VectorLib vecLib;
	public CueBall[] balls;
	public WallToLine[] walls;
	private bool ballExited, wallExited;

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
	    if (wall.transform.rotation.y == 0 || wall.transform.rotation.y == 180)
		{
			Debug.Log("Reflected Z axis");
			velocity = vecLib.ReflVecAxisAlign(velocity, 'z'); 
		}
		else
		{
			Debug.Log("Reflected X axis");
			velocity = vecLib.ReflVecAxisAlign(velocity, 'x');
		}
    }

    void Start()
    {
	    ballExited = true;
	    wallExited = true;
    }

    void BallCollisionHandler(CueBall ball2)
    {
	    
	    float velocityScalar = vecLib.DotVec(vecLib.SubVec(velocity, ball2.velocity), vecLib.SubVec(transform.position, ball2.transform.position)) / Mathf.Pow(vecLib.MagVec(vecLib.SubVec(transform.position, ball2.transform.position)), 2f);
	    float massCalc = velocityScalar * (2 * ball2.mass) / mass + ball2.mass;
	    velocity = vecLib.SubVec(velocity, vecLib.ScalarMultVec(vecLib.SubVec(transform.position, ball2.transform.position), massCalc));
    }
	
    // Update is called once per frame
    void Update()
    {
	    foreach (WallToLine i in walls)
	    {
		    bool onLine = (vecLib.isOnLine(transform.position, i.position1, i.position2,
			    transform.localScale.x / 2 + i.transform.localScale.z / 2));
		    if ( onLine && wallExited)
		    {
			    wallExited = false; // Very cheap and risky but better than creating a class at the moment
			    WallCollisionHandler(i);
			}
		    if (!onLine)
		    {
			    wallExited = true;
		    }
	    }

	    foreach (CueBall i in balls)
	    {
		    bool ballCol = (vecLib.checkSphereCol(transform.position, i.transform.position, transform.localScale.x / 2,
			    i.transform.localScale.x / 2));
		    if (ballCol && ballExited)
		    {
				ballExited = false;
				BallCollisionHandler(i);
		    }
			if (!ballCol)
		    {
			    ballExited = true;
		    }
	    }

		// Friction
		velocity = vecLib.AddVec(velocity, vecLib.ScalarMultVec(velocity, -friction * Time.deltaTime));
		FrictionToleranceHandler();

		// Velocity transform
		transform.position = vecLib.AddVec(transform.position, vecLib.ScalarMultVec(velocity, Time.deltaTime));


		/* 
         DONE Check collision between walls
         DONE Then find the axis of the wall and 

		 DONE use Axis Aligned Reflection Function from the vecLib to reflect the ball accordingly
         DONE Add friction
        
         DONE Part B
        */
	}

}
