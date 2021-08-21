using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class BestScoreText : MonoBehaviour {

	public Text bestScore;

	// Use this for initialization
	void Start () {
		bestScore = GetComponent<Text>();
		bestScore.text = PlayerPrefs.GetInt("BestScore").ToString();
	}
	
}
