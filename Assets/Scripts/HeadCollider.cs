using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCollider : MonoBehaviour {

    EnemyHealth enemyHealthScript;
    float depth = 0.30F;
    public GameObject explosion;
    GameObject blood;

    // Use this for initialization
    void Start ()
    {
        //enemyHealthScript = GameObject.Find("enemy character rig").GetComponent<EnemyHealth>();
        enemyHealthScript = transform.parent.GetComponent<EnemyHealth>();
    }
	
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "arrow")
        {
            //Debug.Log("Head Shot !!!!!!!!!!!");

            // Spawn an explosion at each point of contact
            foreach (ContactPoint2D missileHit in collision.contacts)
            {
                Debug.Log(collision.contacts.Length);
                Vector2 hitPoint = missileHit.point;
                blood = Instantiate(explosion, new Vector3(hitPoint.x, hitPoint.y, 0), Quaternion.identity);
                //blood.transform.parent = transform.parent;
                StartCoroutine(ExecuteAfterTime());
            }
            enemyHealthScript.takeDamage(30);            
            
        }
    }

    IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(1);
        // Code to execute after the delay
        if (blood.activeSelf)
        {
            Color tmp = blood.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            blood.GetComponent<SpriteRenderer>().color = tmp;
            Destroy(blood);
        }
             
    }
}
