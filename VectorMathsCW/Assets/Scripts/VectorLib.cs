using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLib : MonoBehaviour
{
	public Vector3 ZeroVec() // Returns a vector with zero for x y z
	{
		return new Vector3(0, 0, 0);
	}

	public Vector3 AddVec(Vector3 vec1, Vector3 vec2) // creates a new vector adding two vectors together x+x y+y z+z.
	{
		return new Vector3(vec1.x + vec2.x, vec1.y + vec2.y, vec1.z + vec2.z);
	}
	
	public Vector3 SubVec(Vector3 vec1, Vector3 vec2) // creates a new vector subtracting two vectors x-x y-y z-z.
	{
		return new Vector3(vec1.x - vec2.x, vec1.y - vec2.y, vec1.z - vec2.z);
	}
	public Vector3 ScalarMultVec(Vector3 vec1, float multiple) // creates a new vector x*a y*a z*a
	{
		return new Vector3(vec1.x * multiple, vec1.y * multiple, vec1.z * multiple);
	}
	
	public float DotVec(Vector3 vec1, Vector3 vec2) // Finds the dot product of two vectors (x*x+y*y+z*z)
	{
		return (vec1.x * vec2.x) + (vec1.y * vec2.y) + (vec1.z * vec2.z);
	}
	public Vector3 CrossVec(Vector3 vec1, Vector3 vec2) // Same as dot product but doesn't add x y z together.
	{
		return new Vector3(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z);
	}

	public float MagVec(Vector3 vec1) // Finds the distance of vector from origin
	{
		return Mathf.Sqrt(Mathf.Pow(vec1.x, 2.0f) + Mathf.Pow(vec1.y, 2.0f) + Mathf.Pow(vec1.z, 2.0f));
	}
	public Vector3 UnitVec(Vector3 vec1) // finds the direction vector of a vector from 0 origin
	{
		float magnitude = MagVec(vec1);
		return new Vector3(vec1.x / magnitude, vec1.y / magnitude, vec1.z / magnitude);
	}

	public Vector3 UnitDirVec(Vector3 vec1, Vector3 vec2) // Finds the direction vector of two vectors
	{
		Vector3 tempVec = SubVec(vec1, vec2);
		return UnitVec(tempVec);
	}

	public Vector3 ReflVecAxisAlign(Vector3 vec1, char axis) // Inverts one value in the vector based on chosen axis.
	{
		switch (axis)
		{
			case 'x':
				vec1.x = -vec1.x;
				break;
			case 'y':
				vec1.y = -vec1.y;
				break;
			case 'z':
				vec1.z = -vec1.z;
				break;
			default:
				Debug.Log("Invalid axis, vector was not reflected.");
				break;
		}
		return vec1;
	}

	public Vector3 GetPerpendicular(Vector3 linePoint1, Vector3 linePoint2) // Finds the perpendicular line of a vector line.
	{
		return new Vector3(-linePoint2.z+linePoint1.z, 0, linePoint2.x - linePoint1.x);
	}

	public bool isMovingTowards(Vector3 targetPoint, Vector3 objectPoint, Vector3 objectVelocity) // Checks if object 1 is moving towards target
	{
		return DotVec(SubVec(targetPoint, objectPoint), objectVelocity) >= 0;
	}

	public bool isOnLine(Vector3 objectPoint, Vector3 linePoint1, Vector3 linePoint2, float tolerance) // Finds vector distance to line and checks distance against tolerance.
	{
		Vector3 perpendicular = GetPerpendicular(linePoint1, linePoint2); 
		return (Mathf.Abs(DotVec(SubVec(objectPoint, linePoint1), perpendicular)) / MagVec(perpendicular) < tolerance);
		// Uses Pythag between the angle of linepoint1 -> objectpoint and perpendicular of the line, to find the distance between the point and the line.
	}

	public Vector3 ToSphericalCartes(Vector3 polarVec) // Converts spherical coordinates to cartesian
	{
		Vector3 cartesVec;
		cartesVec.x = polarVec.x * Mathf.Sin(polarVec.z) * Mathf.Cos(polarVec.y);
		cartesVec.y = polarVec.x * Mathf.Sin(polarVec.z) * Mathf.Sin(polarVec.y);
		cartesVec.z = polarVec.x * Mathf.Cos(polarVec.z);
		return cartesVec;
	}

	public Vector3 ToSphericalPolar(Vector3 cartesVec) // Converts cartesian coordinates to spherical
	{
		Vector3 sphericalVector;
		sphericalVector.x = Mathf.Sqrt(Mathf.Pow(cartesVec.x, 2)+ Mathf.Pow(cartesVec.y, 2)+ Mathf.Pow(cartesVec.z, 2));
		sphericalVector.y = Mathf.Atan2(cartesVec.y, cartesVec.x);
		sphericalVector.z = Mathf.Acos(cartesVec.z / Mathf.Sqrt(Mathf.Pow(cartesVec.x, 2) + Mathf.Pow(cartesVec.y, 2) + Mathf.Pow(cartesVec.z, 2)));
		return sphericalVector;
	}

	public bool CheckSphereCol(Vector3 objectPoint1, Vector3 objectPoint2, float radius1, float radius2) // Checks if two spheres are close than the sum of their radii
	{
		return (MagVec(SubVec(objectPoint1, objectPoint2)) < radius1 + radius2);
	}
	

	// TODO Comment for UnitDirVec, DirVec and OnLine
}
