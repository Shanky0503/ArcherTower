using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    private int score { get; set; }
    public Text scoreText; 

	// Use this for initialization
	void Start ()
    {
        score = 0;	
	}

    public void updateScore(int scoreValue)
    {
        score += scoreValue;
        scoreText.text = score.ToString();
        //Debug.Log(score);
    }


}
