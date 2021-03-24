using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen: MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {

		Vector2 temp1 = player.transform.position;
		temp1.x = PlayerPrefs.GetFloat ("PlayerTransformX");
		temp1.y = PlayerPrefs.GetFloat ("PlayerTransformY");
		player.transform.position = temp1;
	}
}