using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour {

    EnemyHealth enemyHealthScript;

	// Use this for initialization
	void Start ()
    {
        enemyHealthScript = GameObject.Find("enemy character rig").GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            //Debug.Log("Head Shot !!!!!!!!!!!");
            enemyHealthScript.takeDamage(50);
        }
    }
}
