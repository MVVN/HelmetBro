using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class POTGWaitSeconds : MonoBehaviour {
    new AudioSource audio;
	public Image blackScreen;
	bool ended = false;

    // Use this for initialization
    void Start()
    {
		StartCoroutine ("FadeIn");
		audio = GetComponent<AudioSource> ();    
    }

    void Update()
    {
        if (audio.isPlaying == false)
        {
			if (ended == false) {			
				ended = true;
				StartCoroutine ("FadeOut");
			}           
        }


	}IEnumerator FadeIn(){
		float alpha = 1.5f;

		while (alpha>0) {
			alpha -= Time.deltaTime;
			Color LastColor = blackScreen.color;
			LastColor.a = alpha;
			blackScreen.color = LastColor;

			yield return null;
		}
	}

	IEnumerator FadeOut(){
		float alpha = 0f;

		while (alpha<1) {
			alpha += Time.deltaTime;
			Color LastColor = blackScreen.color;
			LastColor.a = alpha;
			blackScreen.color = LastColor;

			yield return null;
		}
		SceneManager.LoadScene ("07_End");
	}       
}
