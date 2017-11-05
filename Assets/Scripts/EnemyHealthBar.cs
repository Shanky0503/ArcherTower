using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour {

    float initialgreenBarPos;
    float finalgreenBarPos;
    GameObject greenBar;
    //float greenBarStartPosition = 0.45f;
    //float greenBarEndPosition = -3.7f;
    float health;
    float maxhealth;

    EnemyHealth enemyHealthScript;
    //Transform greenBarLength;

    // Use this for initialization
    void Awake()
    {
        enemyHealthScript = transform.parent.GetComponent<EnemyHealth>();
        //greenBarLength = this.gameObject.transform.GetChild(0);
        greenBar = this.gameObject.transform.GetChild(0).gameObject;
        //health = enemyHealthScript.currentHealth;
        maxhealth = enemyHealthScript.startingHealth;
        health = maxhealth;
        initialgreenBarPos = 0.450f;
        finalgreenBarPos = -3.722f;
        //Debug.Log(initialGreenLength);
    }

    // Update is called once per frame
    void updateHealthBar()
    {
        health = enemyHealthScript.currentHealth;
        float differenceBetweenPoints = (initialgreenBarPos - finalgreenBarPos) / maxhealth;
        float differenceBetweenHealth = maxhealth - health;
        //Debug.Log(differenceBetweenPoints + "Difference in points is");
        //Debug.Log(differenceBetweenHealth + "    Difference in health");
        //Debug.Log((differenceBetweenPoints * (differenceBetweenHealth / 100)));
        //Debug.Log(differenceBetweenHealth / 100);
        //Vector2 greenBarPos = new Vector2(( initialgreenBarPos - (differenceBetweenPoints*(differenceBetweenHealth/100))), -0.28f);
        Vector2 greenBarPos = new Vector2(( initialgreenBarPos - (differenceBetweenPoints*differenceBetweenHealth)), -0.28f);
        //Debug.Log(greenBarPos);
        greenBar.transform.localPosition = greenBarPos;
    }
}
