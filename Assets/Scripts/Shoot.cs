using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour {

    public GameObject projectilePrefab;    
	public float mouseAngle;
	public float clampAnglemin = -30;
	public float clampAnglemax = 30;
//	public Quaternion maxAngle = new Quaternion(30,-30,0,0);

//	public Quaternion clampAngle = new Quaternion(30,-30,0,0);

	// Update is called once per frame
	void Update ()
    {
		Quaternion angle = aimAtMousePointer();
		if (Input.GetButtonDown ("Fire1") && angle.z >= clampAnglemin && angle.z <= clampAnglemax) {				
			GameObject arrow = (GameObject)Instantiate (projectilePrefab, transform.position, angle);           	
		} 
	}

    public Quaternion aimAtMousePointer()
    {
        //Aims or rotates the bow towards the mouse pointer
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        mouseAngle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(mouseAngle, clampAnglemin, clampAnglemax)));
        return this.transform.rotation;
    }
}
