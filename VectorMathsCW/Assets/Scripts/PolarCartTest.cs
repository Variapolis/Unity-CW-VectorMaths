using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarCartTest : MonoBehaviour
{
	public Vector3 test;

	public VectorLib vecLib;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Original vector is "+test);
	    Vector3 sphericalTest = vecLib.toSphericalPolar(test);
        Debug.Log("Spherical vector is "+sphericalTest);
        Debug.Log("Cartesian vector is "+vecLib.ToSphericalCartes(sphericalTest));
    }
}
