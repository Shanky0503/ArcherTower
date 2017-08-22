using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LineRenderer))]
public class LaunchArc : MonoBehaviour 
{
	private Shoot shootScript;
	LineRenderer lr;
	public GameObject bow; 
	public float velocity;
	public float angle;
	public int resolution = 20;
	float h;
	Vector3 offset = new Vector3(3,0,0);

	float g; // force of gravity on the y axis
	float radianAngle;

	void Awake () 
	{
		shootScript = GameObject.Find("bow").GetComponent<Shoot>();
		lr = GetComponent<LineRenderer> ();
		g = Mathf.Abs (Physics2D.gravity.y);
		h = bow.transform.position.y;
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
		angle = shootScript.mouseAngle;
		renderArc ();

	}

	//populating the LineRender with appropriate settings
	void renderArc()
	{
		lr.positionCount = resolution + 1;
		lr.SetPositions (calculateArcArray());
	}

	void Update()
	{
		angle = shootScript.mouseAngle;
		//Debug.Log ("Angle recived in launchArc is "+ angle);
		if (lr != null && Application.isPlaying ) {
			if (angle >= -30 && angle <= 30) 
			{
				renderArc ();
			}
		}
	}

	//Create an array of vector3 positions for arc
	Vector3[] calculateArcArray()
	{
		Vector3[] arcArray = new Vector3[resolution+1];
		radianAngle = Mathf.Deg2Rad * angle;
		//float maxDistance = (velocity * velocity * Mathf.Sin (2 * radianAngle)) / g;
		float maxDistance = ((velocity * Mathf.Cos (radianAngle))/g)*(velocity*Mathf.Sin (radianAngle)+Mathf.Sqrt (velocity*Mathf.Sin (radianAngle)*velocity*Mathf.Sin (radianAngle)+2*g*h));
		//Debug.Log (maxDistance);
		Vector3 endpoint = calculateArcArray ();

		for (int i = 0; i <= resolution; i++) 
		{
			float t = (float)i / (float)resolution;
			arcArray [i] = calculateArcPoint (t, maxDistance);
		}
		return arcArray;
	}

	//calculate heignt and distancene of each vertex
	Vector3 calculateArcPoint(float t, float maxDistance)
	{
		float x = t * maxDistance;
		float y = h + x * Mathf.Tan (radianAngle) - ((g * x * x) / (2 * velocity * velocity * Mathf.Cos (radianAngle) * Mathf.Cos (radianAngle)));
		return new Vector3 (x,y)+ offset;
	}
}
