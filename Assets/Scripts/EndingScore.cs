using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndingScore : MonoBehaviour {
	public Text scoreText;

	// Use this for initialization
	void Start () {
		scoreText.text = "Score: " + Mathf.Round(PlayerPrefs.GetFloat("Score"));
	}
	public void MainMenu (){
		SceneManager.LoadScene("03_Menu");
	}
	public void Replay (){
		SceneManager.LoadScene("04_Game");
	}
}
