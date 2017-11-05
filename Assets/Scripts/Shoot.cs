using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour {

    public GameObject projectilePrefab;    
	private float mouseAngle;
	private float timeBetweenArrows = 0.45f;
	private float clampAngleMin = -55;
	private float clampAngleMax = 15;

	float timer;

	// Update is called once per frame
	void Update ()
    {
		timer += Time.deltaTime;
		aimAtMousePointer();		
		if (Input.GetButtonDown ("Fire1") && timer >= timeBetweenArrows) 
		{           
            GameObject arrow = (GameObject)Instantiate (projectilePrefab, transform.position, this.transform.rotation);
            timer = 0f;
        }
	}	

	public float getMouseAngle()
	{
		return mouseAngle;
	}


	public void aimAtMousePointer()
    {
        //Aims or rotates the bow towards the mouse pointer
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        mouseAngle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		mouseAngle = Mathf.Clamp (mouseAngle, clampAngleMin, clampAngleMax);
		this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, mouseAngle));
		       
    }
}
