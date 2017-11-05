using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth;
	public int currentHealth;
	public int scoreValue = 10;
	Transform spawnPoint;
	public bool isDead { get; private set;}
	EnemyHealthBar healthBar;
    SpawnEnemies spawnManager;
    ScoreManager scoreManager;

	// Use this for initialization
	void Start () 
	{
        
        currentHealth = startingHealth;
        healthBar = gameObject.GetComponentInChildren<EnemyHealthBar>();
        spawnManager = GameObject.Find("EnemyManager").GetComponent<SpawnEnemies>();
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        
//		healthBar.value = calculatedHealth ();		
	}

    void Update()
    {
       
    }

	public void takeDamage (int amount)
	{
		if (isDead)
			return;
        
		currentHealth -= amount;
        healthBar.SendMessage("updateHealthBar");
//		healthBar.value = calculatedHealth ();
        if (currentHealth <= 0) 
		{
			death ();
		}
	}

	int calculatedHealth ()
	{
		return currentHealth / startingHealth;
	}

	void death() 
	{
		//Debug.Log ("Dead !!!!!!!");
		isDead = true;        
		Destroy (transform.parent.gameObject);
        spawnManager.SendMessage("Spawn");
        scoreManager.updateScore(scoreValue);
	}

}
