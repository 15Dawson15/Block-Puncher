using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring : MonoBehaviour {

    public Text score;
    public int currentScore;

	// Use this for initialization
	void Start () {
        currentScore = 0;
        score = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        score.text = "Score: " + currentScore.ToString();
	}

    public void IncreaseScore(int number)
    {
        currentScore += number;
    }
}
