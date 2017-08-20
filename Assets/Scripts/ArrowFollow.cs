using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollow : MonoBehaviour {
    Rigidbody2D rb;
	private bool _rotate;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		Debug.Log (rb.name);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 vel = rb.velocity;
		if(_rotate)
			transform.rotation = Quaternion.LookRotation(vel);
	}
}
