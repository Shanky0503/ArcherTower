using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public int scoreValue = 10;
	Transform spawnPoint;
	bool isDead;
	public Slider healthBar;

	// Use this for initialization
	void Start () 
	{
		currentHealth = startingHealth;
//		healthBar.value = calculatedHealth ();		
	}	

	public void takeDamage (int amount)
	{
		if (isDead)
			return;

		currentHealth -= amount;
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
//		Destroy (healthBar);
	}

}
