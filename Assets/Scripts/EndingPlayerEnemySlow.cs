using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// used for slow replay in POTG (Play of the Game)
public class EndingPlayerEnemySlow : MonoBehaviour {
	public GameObject player, enemy;
//	Renderer renderer2;
	private float speed = 1.5f;
	public float movespeed;
	private bool finishedIntro = false;
	// Use this for initialization
	void Start () {
		Vector2 temp1 = player.transform.position;
		temp1.x = 2f;
		temp1.y = PlayerPrefs.GetFloat ("PlayerTransformY");
		player.transform.position = temp1;

		Vector2 temp2 = enemy.transform.position;
		temp2.x = PlayerPrefs.GetFloat ("EnemyTransformX") + 1;
		temp2.y = PlayerPrefs.GetFloat ("EnemyTransformY");
		enemy.transform.position = temp2;
/**
		Vector2 temp3 = renderer.material.mainTextureOffset;
		temp3 = new Vector2 (PlayerPrefs.GetFloat ("Offset"), 0);
		renderer.material.mainTextureOffset = temp3;

		Vector2 temp4 = renderer2.material.mainTextureOffset;
		temp4 = new Vector2 (PlayerPrefs.GetFloat ("Offsethimmel"), 0);
		renderer2.material.mainTextureOffset = temp4;
**/
		StartCoroutine ("waitForIntro");
	}
	
	// Update is called once per frame
	void Update () {		// when Video finished playing the slow replay can start
		if (finishedIntro) {
			float targetPos = player.transform.position.y;
			float sionPos = enemy.transform.position.y;
			sionPos = Mathf.Lerp (enemy.transform.position.y, targetPos, Time.deltaTime * speed);
			float tempS = enemy.transform.position.x + movespeed;
			enemy.transform.position = new Vector2(tempS, sionPos);
		}		
	}
	IEnumerator waitForIntro(){			// waits for Video to end
		yield return new WaitForSeconds (5.8f);
		finishedIntro = true;
		StopCoroutine ("waitForIntro");
	}
}