using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Test : MonoBehaviour
{
	public Vector3 vec1;
	public Vector3 vec2;
	public Vector3 linePoint1, linePoint2;
	public float lineTolerance, scalarMult;
	public float radius1, radius2;
	private Vector3 polar;

	// Start is called before the first frame update
    void Start()
    {
        Debug.Log("Original vector 1 is "+ vec1);
        Debug.Log("Original vector 2 is " + vec2);
        Debug.Log("New Zero Vector is " + VectorLib.ZeroVec());
        Debug.Log("Added Vectors are " + VectorLib.AddVec(vec1,vec2));
        Debug.Log("Subbed Vectors are " + VectorLib.SubVec(vec1, vec2));
        Debug.Log("Dot product of Vector 1 and 2 is " +VectorLib.DotVec(vec1, vec2));
        Debug.Log($"Vector 1 ScalarMult by {scalarMult} is " +VectorLib.ScalarMultVec(vec1, 5));
        Debug.Log("Cross product Vector 1 and 2 is " +VectorLib.CrossVec(vec1, vec2));
        Debug.Log("Magnitude of Vector1 is " +VectorLib.MagVec(vec1));
        Debug.Log("Unit Vector of Vector 1 is " +VectorLib.UnitVec(vec1));
        Debug.Log("Unit Vector of Vector 1 to 2 is " +VectorLib.UnitDirVec(vec1, vec2));
        Debug.Log("Vector 1 reflected along axis x is " +VectorLib.ReflVecAxisAlign(vec1, 'x'));
        Debug.Log($"Checking if Vector 1 is on the line between {linePoint1} and {linePoint2} with a tolerance of {lineTolerance} results in "+VectorLib.isOnLine(vec1, linePoint1, linePoint2, lineTolerance));
        polar = VectorLib.ToSphericalCartes(vec1);
        Debug.Log($"Vector 1 in polar is {polar}");
        Debug.Log("Converted back to cartesian is " +VectorLib.ToSphericalPolar(polar));
        Debug.Log($"Sphere collision check by Vector 1 and 2 with radii {radius1} and {radius2} results in {VectorLib.CheckSphereCol(vec1, vec2, radius1, radius2)} ");
        


    }
}
