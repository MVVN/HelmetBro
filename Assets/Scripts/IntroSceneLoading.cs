using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class IntroSceneLoading : MonoBehaviour {
	public Text loadingLabel;
	bool loading = false;

	void Update() 
	{
        if (Input.anyKeyDown && loading == false) {
            SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
            loading = true;
            if (loadingLabel != null) {
                loadingLabel.text = "Loading - Please wait. . .";
            }
        }
    }
}
