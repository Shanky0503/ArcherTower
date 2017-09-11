using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampHealthBar : MonoBehaviour {


	public Transform target;

	void Update ()
	{
		var wantedPos = Camera.main.WorldToScreenPoint (target.position);
		transform.position = wantedPos;
	}



}
