using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for DeathScene
public class EndingPlayerEnemy : MonoBehaviour {
	public GameObject player, enemy;
    new Renderer renderer;
	Renderer renderer2;
	private float speed = 1.5f;
	public float movespeed;
	// Use this for initialization
	void Start () {		// get position of characters before game ended

		Vector2 temp1 = player.transform.position;
		temp1.x = PlayerPrefs.GetFloat ("PlayerTransformX");
		temp1.y = PlayerPrefs.GetFloat ("PlayerTransformY");
		player.transform.position = temp1;

		Vector2 temp2 = enemy.transform.position;
		temp2.x = PlayerPrefs.GetFloat ("EnemyTransformX");
		temp2.y = PlayerPrefs.GetFloat ("EnemyTransformY");
		enemy.transform.position = temp2;
	}
	
	// Update is called once per frame
	void Update () {
			float targetPos = player.transform.position.y;
			float sionPos = enemy.transform.position.y;
			sionPos = Mathf.Lerp (enemy.transform.position.y, targetPos, Time.deltaTime * speed);
			float tempS = enemy.transform.position.x + movespeed;
			enemy.transform.position = new Vector2(tempS, sionPos);
	}

}