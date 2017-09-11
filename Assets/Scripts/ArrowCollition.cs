using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollition : MonoBehaviour 
{
	//Rigidbody2D rb2d;
	void Start()
	{
		//rb2d = GetComponent<Rigidbody2D>();	
	}

    Transform child;

	// Checking if arrow is colliding with enemy and dealing damage
	void OnCollisionEnter2D (Collision2D coll)
	{
        
        //Debug.Log(coll.gameObject.name);
        //Transform t = GameObject.Find("enemy character rig");

        Transform childObject = coll.gameObject.transform.GetChild(0);


        if (childObject.tag == "head")
        {
            //Debug.Log("HEAD SHOT");
            ////coll.gameObject.SendMessage("takeDamage", 50);
            //if (rb2d != null)
            //    rb2d.isKinematic = true;
        }
        else if (coll.gameObject.tag == "body")
        {
            //Debug.Log("BODY SHOT :(");
        }
	}
}
