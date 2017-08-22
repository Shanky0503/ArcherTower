using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour {

    public GameObject projectilePrefab;
    private List<GameObject> Projectiles = new List<GameObject>();

    private float projectileVelocity;
	public float mouseAngle;
	public float firedAngle;
	 
	// Use this for initialization
	void Start ()
    {
        projectileVelocity = 15;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion mouseAngle = aimAtMousePointer();
             

        // on mouse press releases the arrow
        if (Input.GetButtonDown("Fire1"))
        {
			Quaternion firedAngle = mouseAngle;
            GameObject arrow = (GameObject)Instantiate(projectilePrefab, transform.position, mouseAngle);
            Projectiles.Add(arrow);
        }
        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goArrow = Projectiles[i];
            if (goArrow != null)
            {
                goArrow.transform.Translate(new Vector2(1,0) * Time.deltaTime * projectileVelocity);
				//goArrow.GetComponent<Rigidbody2D>().AddForce(goArrow.transform.right * projectileVelocity);
                destroyOnArrowOnBounds(goArrow);
            }
        }
		
	}

    void destroyOnArrowOnBounds(GameObject goArrow)
    {
//        Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goArrow.transform.position);
//        if (bulletScreenPos.y >= Screen.height + 100 || bulletScreenPos.y <= 30)
//        {
//            DestroyObject(goArrow);
//            Projectiles.Remove(goArrow);
//        }
    }

    public Quaternion aimAtMousePointer()
    {
        //Aims or rotates the bow towards the mouse pointer
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        mouseAngle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
//		Debug.Log ("angle of mouse movement"+angle);
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(mouseAngle, -30, 30)));

        return this.transform.rotation;
    }
}
