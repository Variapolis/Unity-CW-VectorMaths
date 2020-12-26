using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLib : MonoBehaviour
{
	public Vector3 ZeroVec()
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
				Debug.Log("Incorrect axis, vector was not reflected.");
				break;
		}
		return vec1;
	}

	public bool isOnLineAxisAligned(Vector3 objectPoint, Vector3 linePoint1, Vector3 linePoint2)
	{
		//if ()
		//{
		//	return true;
		//}

		return false;
	}

	public Vector3 ToCartes(Vector3 polarVec) // TODO NOT COMPLETE
	{
		return new Vector3(0,0,0);
	}

	public Vector3 toPolar(Vector3 cartesVec) // TODO NOT COMPLETE
	{
		return new Vector3((float)Mathf.Sin(cartesVec.x) ,0,0);
	}

	// TODO Polar to Cartes and Vice versa needed -Doing- 
	// TODO Vector reflection needed
	// TODO 3D Zero Vector
	// TODO Point on Line check
	// TODO Vector nearly equal with radius
}
