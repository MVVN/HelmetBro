using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// Script to get Game to MainMenu in case the player went away

public class AFK_Timer : MonoBehaviour {		

	private float timer = 0;
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown)
			resetTimer ();
		else
			tick ();		

		if (timer > 60) {
			SceneManager.LoadScene ("03_Menu");
		}
	}

	void resetTimer ()
	{
		timer = 0;
	}

	void tick ()
	{
		timer += Time.deltaTime;
	}
}
