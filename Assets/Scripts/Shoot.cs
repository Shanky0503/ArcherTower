using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shoot : MonoBehaviour {

    public GameObject projectilePrefab;
    private List<GameObject> Projectiles = new List<GameObject>();

    private float projectileVelocity;

	// Use this for initialization
	void Start ()
    {
        projectileVelocity = 12;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Quaternion mouseAngle = aimAtMousePointer();
             

        // on mouse press releases the arrow
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject arrow = (GameObject)Instantiate(projectilePrefab, transform.position, mouseAngle);
            Projectiles.Add(arrow);
        }
        for (int i = 0; i < Projectiles.Count; i++)
        {
            GameObject goArrow = Projectiles[i];
            if (goArrow != null)
            {
                goArrow.transform.Translate(new Vector2(1,0) * Time.deltaTime * projectileVelocity);
                destroyOnArrowOnBounds(goArrow);
            }
        }
		
	}

    void destroyOnArrowOnBounds(GameObject goArrow)
    {
        Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goArrow.transform.position);
        if (bulletScreenPos.y >= Screen.height + 100 || bulletScreenPos.y <= 30)
        {
            DestroyObject(goArrow);
            Projectiles.Remove(goArrow);
        }
    }

    Quaternion aimAtMousePointer()
    {
        //Aims or rotates the bow towards the mouse pointer
        Vector3 mouse_pos = Input.mousePosition;
        Vector3 player_pos = Camera.main.WorldToScreenPoint(this.transform.position);

        mouse_pos.x = mouse_pos.x - player_pos.x;
        mouse_pos.y = mouse_pos.y - player_pos.y;

        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Clamp(angle, -90, 90)));

        return this.transform.rotation;
    }
}
