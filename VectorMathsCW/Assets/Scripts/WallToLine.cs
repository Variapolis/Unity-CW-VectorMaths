using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallToLine : MonoBehaviour
{
	public Vector3 position1, position2;
	public VectorLib vecLib;


	Vector3 GetLongEdge()
	{
		Vector3 edgeVector;
		if (transform.rotation.y == 0 || transform.rotation.y == 180)
		{
			edgeVector = new Vector3(transform.position.x - transform.localScale.x/2, transform.position.y, transform.position.z);
		}
		else
		{
			edgeVector = new Vector3(transform.position.x, transform.position.y, transform.position.z - transform.localScale.x / 2);
		}
		return edgeVector;
	}

	// Start is called before the first frame update
	void Start()
	{
		position1 = GetLongEdge();
		position2 = vecLib.AddVec(transform.position, vecLib.ScalarMultVec(vecLib.SubVec(transform.position, position1), 1));
	}
}
