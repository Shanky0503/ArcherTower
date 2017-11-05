using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampHealthBar : MonoBehaviour
{


	//public GameObject[] target;
    //public List<GameObject> targets = new List<GameObject>();
    public GameObject target;


    void FixedUpdate ()
	{
        //if (targets != null)
        //{
        //    targets.AddRange(GameObject.FindGameObjectsWithTag("enemy"));

        //    foreach (var target in targets)
        //    {
        //        var wantedPos = Camera.main.WorldToScreenPoint(target.transform.position);
        //        transform.position = wantedPos;
        //    }
        //}

        //var wantedPos = Camera.main.WorldToScreenPoint(target.position);
        this.transform.position = target.transform.position;
    }
}
