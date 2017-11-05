using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollider : MonoBehaviour
{

    EnemyHealth enemyHealthScript;

    // Use this for initialization
    void Start()
    {
        enemyHealthScript = transform.parent.GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            //Debug.Log("Body Shot @@@@@@");
            //collision.gameObject.SendMessage("takeDamage", 10);
            enemyHealthScript.takeDamage(20);
        }
    }
}
