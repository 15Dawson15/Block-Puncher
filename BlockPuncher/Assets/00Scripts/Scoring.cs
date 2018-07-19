using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour {

    private TextMeshProUGUI textMesH;

   // public Text score;
    private int currentScore;

	// Use this for initialization
	void Start () {
        currentScore = 0;
        //score = GetComponent<Text>();
        textMesH = GetComponent<TextMeshProUGUI>();
	}
	
	// Update is called once per frame
	void Update () {
        //score.text = "Score: " + currentScore.ToString();
        textMesH.text = "Score: " + currentScore.ToString();
	}

    public void IncreaseScore(int number)
    {
        currentScore += number;
    }

    public void SetCurrentScore(int number)
    {
        currentScore = number;
    }
}
