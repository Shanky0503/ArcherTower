using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour {

	public GameObject enemyPrefab;                // The enemy prefab to be spawned.
	public float spawnTime = 3f;            // How long between each spawn.
	public Transform spawnPoint;         // An array of the spawn points this enemy can spawn from.
	public Text enemyBar;
	//ClampHealthBar clampScript;
	Transform healthPlaceHolder;

	void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		//clampScript = GetComponentInChildren<ClampHealthBar> ();
		healthPlaceHolder = GetComponentInChildren<Transform> ();
//		Debug.Log (healthPlaceHolder);
	}

	void cancelSpawning ()
	{
		CancelInvoke ();
	}

	void Update ()
	{
		Vector2 barPos = Camera.main.WorldToScreenPoint (healthPlaceHolder.position);
	}


	void Spawn ()
	{		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
		Text sliderVariable = Instantiate (enemyBar,healthPlaceHolder.position, healthPlaceHolder.rotation);
		sliderVariable.transform.SetParent (GameObject.Find ("Canvas").transform,false);

        //      clampscript.sendmessage("assignobjects", slidervariable);
        //		clampScript.assignObjects (sliderVariable);

    }
}
