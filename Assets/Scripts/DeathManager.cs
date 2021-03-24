using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathManager : MonoBehaviour {
	public static DeathManager instance;
	public GameObject Player;
	public GameObject Enemy;

	void Start() {
        DeathManager.instance = this;
	}

	public void death(){		// called when player loses all 3 Hearts or ran into trap while on last "level"
								// stores values, used for Endscenes (remember Characters last Position)

		PlayerMovement.instance.enabled = false;
		Scroll.instance.scrolling = false;
		SpawnManager.instance.StopAllCoroutines();
		PlayerPrefs.SetFloat ("Score", ScoreManager.instance.scoreCount);
		PlayerPrefs.SetFloat ("PlayerTransformX", Player.transform.position.x);
		PlayerPrefs.SetFloat ("PlayerTransformY", Player.transform.position.y);
		PlayerPrefs.SetFloat ("EnemyTransformX", Enemy.transform.position.x);
		PlayerPrefs.SetFloat ("EnemyTransformY", Enemy.transform.position.y);
		SceneManager.LoadScene ("05_Lose");
	}
}
