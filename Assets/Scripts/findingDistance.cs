using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findingDistance : MonoBehaviour {


	Rigidbody2D rb;
	//public GameObject bow;
	float d;
	float v;
	float g;
	float angle;
	float radianAngle;	
	float h;

	void Awake () 
	{	
		rb = GetComponent<Rigidbody2D>();	
		g = Mathf.Abs (Physics2D.gravity.y);
		v = rb.velocity.y;
//		Debug.Log ("Velovity = "+ v);
		angle = rb.transform.rotation.y;
		radianAngle = Mathf.Deg2Rad * angle;	
		h = this.transform.position.y;

	}
	// Use this for initialization
	void Start () {
	}

	float distanceTravelled ()
	{
		float section01 = (v * v) / (2 * g);
		float subSection01 = (2 * g * h);
		float subSection02 = v * v * Mathf.Sin (radianAngle) * Mathf.Sin (radianAngle);
		float section02 = 1 + Mathf.Sqrt (subSection01/subSection02);
		float section03 = Mathf.Sin (2 * radianAngle);

		d = section01 * section02 * section03;
//		Debug.Log (section01);
//		Debug.Log (subSection01);
//		Debug.Log (section02);
//		Debug.Log (section03);
		return d;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (distanceTravelled ());		
	}
}
