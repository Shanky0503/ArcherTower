using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileArc : MonoBehaviour {

//	[Tooltip("Position we want to hit")]
	public Vector3 targetPos;
	Vector3 finalPoint;
	Vector3[] points;
	int index = 1;

	private LaunchArc launchArc;
    ArrowCollition collitionScript;
//	private Shoot shootScript;
//	[Tooltip("Horizontal speed, in units/sec")]
	private float speed = 10;

	void Start() {
		// Cache our start position, which is really the only thing we need
		// (in addition to our current position, and the target).
		launchArc = GameObject.Find ("launchArc").GetComponent<LaunchArc> ();
        collitionScript = gameObject.GetComponent<ArrowCollition>();
//		shootScript = GameObject.Find("bow").GetComponent<Shoot>();
		targetPos = launchArc.endPoint;
		points = launchArc.calculateArcArray();
	}

	void Update() 
	{		
		Vector3 nextPos;
        if (collitionScript.getHit() == false)
        {
            if (index < points.Length - 1)
            {
                nextPos = new Vector3(points[index].x, points[index].y, transform.position.z);
                transform.rotation = LookAt2D(nextPos - transform.position);
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), nextPos, speed * Time.deltaTime);
                if (nextPos == transform.position)
                {
                    index++;
                }
                if (index == points.Length - 1)
                {
                    Arrived();
                }
                if (nextPos == targetPos) Arrived();
            }

        }
		
	}

	void destroyObjects() {
		Destroy (gameObject);
	}

	void Arrived() {
		Destroy(gameObject);
	}

	/// 
	/// This is a 2D version of Quaternion.LookAt; it returns a quaternion
	/// that makes the local +X axis point in the given forward direction.
	/// 
	/// forward direction
	/// Quaternion that rotates +X to align with forward
	static Quaternion LookAt2D(Vector2 forward) {
//		Debug.Log (forward);
		return Quaternion.Euler(0, 0, Mathf.Atan2(forward.y, forward.x) * Mathf.Rad2Deg);
	}
}
