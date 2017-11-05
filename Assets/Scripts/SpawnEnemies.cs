using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemies : MonoBehaviour {

	public GameObject[] enemyPrefab;          // The enemy prefab to be spawned.
	public float spawnTime = 3f;             // How long between each spawn.
	public Transform spawnPoint;            //the spawn point this enemy can spawn from.
	public GameObject enemyBar;   
	//ClampHealthBar clampScript;
	//Transform healthPlaceHolder;
    EnemyHealth enemyHealthScript;
    int deadEnemies = 0;

    void Start ()
	{
		// Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
		//InvokeRepeating ("Spawn", spawnTime, spawnTime);
        //clampScript = GameObject.Find("E_Bar Parent (clone)").GetComponent<ClampHealthBar>();
		//clampScript = GetComponentInChildren<ClampHealthBar> ();
		//healthPlaceHolder = GetComponentInChildren<Transform> ();
        foreach (var prefab in enemyPrefab)
        {
            enemyHealthScript = prefab.GetComponentInChildren<EnemyHealth>();
        }
        
        //		Debug.Log (healthPlaceHolder);
        Spawn();
	}

	void cancelSpawning ()
	{
		CancelInvoke ();
	}

	void Update ()
	{
		//Vector2 barPos = Camera.main.WorldToScreenPoint (healthPlaceHolder.position);
        if (enemyHealthScript.isDead)
        {
            deadEnemies++;            
        }
	}


	void Spawn ()
	{		
		// Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
		GameObject enemy = Instantiate(enemyPrefab[0], spawnPoint.position, spawnPoint.rotation) as GameObject;
        //Debug.Log(deadEnemies);		
    }

    int randomNumber()
    {
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(0,enemyPrefab.Length);
        return randomNumber;
    }
}
