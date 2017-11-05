using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour {

	Transform player;
	int moveSpeed = 2;
//	int maxDistance = 10;
	int minDistance = 5;
	SpawnEnemies spawnScript;
    public int damage;
  



	// Use this for initialization
	void Awake () 
	{
		player = GameObject.Find ("tower").GetComponent<Transform> ();
	}

	void Start ()
	{
		spawnScript = GameObject.Find ("EnemyManager").GetComponent<SpawnEnemies> ();
	}


	// when colliding with the tower damages the tower

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (coll.gameObject.tag == "tower") 
		{
//			Debug.Log ("Touched Tower :D");
			coll.gameObject.SendMessage ("towerDamage",damage);
		}

	}

	// Update is called once per frame
	void Update () 
	{
		if (player == null) 
		{
			spawnScript.SendMessage ("cancelSpawning");
			return;

		}

		if (Vector3.Distance (transform.position,player.position) >= minDistance) 
		{
			transform.position = Vector3.MoveTowards (transform.position, player.position, moveSpeed * Time.deltaTime);
		}
	}
}
