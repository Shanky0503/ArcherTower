using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerHealth : MonoBehaviour {

	public int startingHealth = 1000;
	public int currentHealth;
//	public int scoreValue = 10;
	bool isDead;
	public Slider healthBar;
//	Rigidbody2D rb;

	// Use this for initialization
	void Start () 
	{
//		rb = GetComponent<Rigidbody2D>();
		currentHealth = startingHealth;
		healthBar.value = startingHealth;		
	}

	void update ()
	{
//		healthBar.value = currentHealth;
	}

	// Update is called once per frame

	public void towerDamage (int amount)
	{
		if (isDead)
			return;

		currentHealth -= amount;		
		healthBar.value = currentHealth;
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
		isDead = true;
		Destroy (gameObject);
	}

}
