using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollow : MonoBehaviour {
    Rigidbody2D rb;
	// Use this for initialization
	public Vector3 vel; 
	void Start () {
		rb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
		vel = rb.velocity;
		this.transform.rotation = Quaternion.LookRotation(vel);
		//Debug.Log (transform.rotation);

		this.transform.Rotate ( 
			Vector3.Slerp(this.transform.right, rb.velocity.normalized, Time.deltaTime));
	}

//	void FixedUpdate(){
//		if(rb.velocity != Vector3.zero)
//			rb.rotation = Quaternion.LookRotation(rb.velocity);  
//	}
}
