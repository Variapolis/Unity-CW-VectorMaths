using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLib : MonoBehaviour
{
	public Vector3 ZeroVec() // TODO Double check if "return new Vector3" is allowed
	{
		return new Vector3(0, 0, 0);
	}

	public Vector3 AddVec(Vector3 vec1, Vector3 vec2)
	{
		Vector3 tempVec;
		tempVec.x = vec1.x + vec2.x;
		tempVec.y = vec1.y + vec2.y;
		tempVec.z = vec1.z + vec2.z;
		return tempVec;
	}
	
	public Vector3 SubVec(Vector3 vec1, Vector3 vec2)
	{
		Vector3 tempVec;
		tempVec.x = vec1.x - vec2.x;
		tempVec.y = vec1.y - vec2.y;
		tempVec.z = vec1.z - vec2.z;
		return tempVec;
	}
	public Vector3 ScalarMultVec(Vector3 vec1, float multiple) // TODO Need double checking
	{
		return new Vector3(vec1.x * multiple, vec1.y * multiple, vec1.z * multiple);
	}
	
	public float DotVec(Vector3 vec1, Vector3 vec2)
	{
		return (vec1.x * vec2.x) + (vec1.y * vec2.y) + (vec1.z * vec2.z);
	}
	public Vector3 CrossVec(Vector3 vec1, Vector3 vec2)
	{
		return new Vector3(vec1.x * vec2.x, vec1.y * vec2.y, vec1.z * vec2.z);
	}

	public float MagVec(Vector3 vec1)
	{
		return Mathf.Sqrt(+Mathf.Pow(vec1.x, 2.0f) + Mathf.Pow(vec1.y, 2.0f) + Mathf.Pow(vec1.z, 2.0f));
	}
	public Vector3 UnitVec(Vector3 vec1) // TODO Need double checking
	{
		float magnitude = MagVec(vec1);
		return new Vector3(vec1.x / magnitude, vec1.y / magnitude, vec1.z / magnitude);
	}

	public Vector3 UnitDirVec(Vector3 vec1, Vector3 vec2) // TODO Unsure if correct or not CHECK LECTURE 6
	{
		Vector3 tempVec = SubVec(vec1, vec2);
		return UnitVec(tempVec);
	}

	public Vector3 ReflVecAxisAlign(Vector3 vec1, char axis)
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

	public Vector3 GetPerpendicular(Vector3 linePoint1, Vector3 linePoint2)
	{
		return new Vector3(-linePoint2.z+linePoint1.z, 0, linePoint2.x - linePoint1.x);
	}

	public bool isOnLine(Vector3 objectPoint, Vector3 linePoint1, Vector3 linePoint2, float tolerance)
	{
		Vector3 perpendicular = GetPerpendicular(linePoint1, linePoint2);
		return (Mathf.Abs(DotVec(SubVec(objectPoint, linePoint1), perpendicular)) / MagVec(perpendicular) < tolerance);
	}

	public Vector3 ToSphericalCartes(Vector3 polarVec) 
	{
		Vector3 cartesVec;
		cartesVec.x = polarVec.x * Mathf.Sin(polarVec.z) * Mathf.Cos(polarVec.y);
		cartesVec.y = polarVec.x * Mathf.Sin(polarVec.z) * Mathf.Sin(polarVec.y);
		cartesVec.z = polarVec.x * Mathf.Cos(polarVec.z);
		return cartesVec;
	}

	public Vector3 toSphericalPolar(Vector3 cartesVec)
	{
		Vector3 sphericalVector;
		sphericalVector.x = Mathf.Sqrt(Mathf.Pow(cartesVec.x, 2)+ Mathf.Pow(cartesVec.y, 2)+ Mathf.Pow(cartesVec.z, 2));
		sphericalVector.y = Mathf.Atan2(cartesVec.y, cartesVec.x);
		sphericalVector.z = Mathf.Acos(cartesVec.z / Mathf.Sqrt(Mathf.Pow(cartesVec.x, 2) + Mathf.Pow(cartesVec.y, 2) + Mathf.Pow(cartesVec.z, 2)));
		return sphericalVector;
	}

	public bool checkSphereCol(Vector3 objectPoint1, Vector3 objectPoint2, float radius1, float radius2)
	{
		return (MagVec(SubVec(objectPoint1, objectPoint2)) < radius1 + radius2);
	}



	// Done Polar to Cartes and Vice versa needed -Doing- 
	// Done Vector reflection needed
	// Done? 3D Zero Vector
	// TODO Point on Line check (DONE BUT NEEDS DOUBLE CHECKING)
	// Done Vector nearly equal with radius
}
