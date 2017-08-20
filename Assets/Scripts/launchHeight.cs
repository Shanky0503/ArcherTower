using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class launchHeight : MonoBehaviour 
{
	LineRenderer lr;

	public float velocity;
	public float angle;
	public float height;
	public int resolution = 10;

	float g; // force of gravity on the y axis
	float radianAngle;

	void Awake () 
	{
		lr = GetComponent<LineRenderer> ();
		g = Mathf.Abs (Physics2D.gravity.y);
	}

	void OnValidate()
	{
		//check that lr is not null and the game is playing
		if (lr != null && Application.isPlaying ) {
			renderArc ();
		}
	}

	void Start ()
	{
		renderArc ();
	}

	//populating the LineRender with appropriate settings
	void renderArc()
	{
		lr.positionCount = resolution + 1;
		lr.SetPositions (calculateArcArray());
	}

	//Create an array of vector3 positions for arc


	Vector3[] calculateArcArray()
	{
		Vector3[] arcArray = new Vector3[resolution+1];
		radianAngle = Mathf.Deg2Rad * angle;

		float maxDistance = (velocity * velocity * Mathf.Sin (2 * radianAngle)) / g;

		for (int i = 0; i <= resolution; i++) 
		{
			float t = (float)i / (float)resolution;
			arcArray [i] = calculateArcPoint (t, maxDistance);
		}

		return arcArray;
	}

	//calculre heignt and distancene of each vertex
	Vector3 calculateArcPoint(float t, float maxDistance){
		float x = t * maxDistance;
		float y = x * Mathf.Tan (radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos (radianAngle) * Mathf.Cos (radianAngle)));

		return new Vector3 (x,y);
	}
}