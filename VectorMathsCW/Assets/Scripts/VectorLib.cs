using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorLib : MonoBehaviour
{
	Vector3 AddVec(Vector3 vec1, Vector3 vec2)
	{
		Vector3 tempVec;
		tempVec.x = vec1.x + vec2.x;
		tempVec.y = vec1.y + vec2.y;
		tempVec.z = vec1.z + vec2.z;
		return tempVec;
	}
	Vector3 SubVec(Vector3 vec1, Vector3 vec2)
	{
		Vector3 tempVec;
		tempVec.x = vec1.x - vec2.x;
		tempVec.y = vec1.y - vec2.y;
		tempVec.z = vec1.z - vec2.z;
		return tempVec;
	}
	Vector3 ScalarMultVec(Vector3 vec1, float multiple) // Need double checking
	{
		return new Vector3(vec1.x * multiple, vec1.y * multiple, vec1.z * multiple);
	}
	float DotVec(Vector3 vec1, Vector3 vec2)
	{
		return (vec1.x * vec2.x) + (vec1.y * vec2.y) + (vec1.z * vec2.z);
	}
	float MagVec(Vector3 vec1)
	{
		return (float)Math.Sqrt(Math.Pow(vec1.x, 2.0) + Math.Pow(vec1.y, 2.0) + Math.Pow(vec1.z, 2.0));
	}
	Vector3 UnitVec(Vector3 vec1) // Need double checking
	{
		float magnitude = MagVec(vec1);
		return new Vector3(vec1.x / magnitude, vec1.y / magnitude, vec1.z / magnitude);
	}

	Vector3 UnitDirVec(Vector3 vec1, Vector3 vec2) // Unsure if correct or not
	{
		Vector3 tempVec = SubVec(vec1, vec2);
		return UnitVec(tempVec);
	}

	// Polar to Cartes and Vice versa needed
	// Vector reflection needed
	// 3D Zero Vector
	// Point on Line check
	// Vector nearly equal with radius
}
