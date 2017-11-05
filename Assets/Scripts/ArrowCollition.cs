using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCollition : MonoBehaviour
{
    bool hit = false;
    //float depth = 0.30F;
    Rigidbody2D rb2d;    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();	
    }

    //Transform child;

    // Checking if arrow is colliding with enemy and dealing damage
    void OnCollisionEnter2D(Collision2D other)
    {
        if (!hit)
        {            
            hit = true;
            Debug.Log(other.gameObject.name);
            transform.parent = other.gameObject.transform;
            Destroy(rb2d);
            Vector3 newPos = transform.localPosition;
            newPos.x = -2;
            transform.localPosition = newPos;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(2);
        // Code to execute after the delay
        

       
    }

    public bool getHit()
    {
        return hit;
    }        
}
