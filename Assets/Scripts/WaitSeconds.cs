using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitSeconds : MonoBehaviour {
	
    // Use this for initialization
    void Start()
    {
		StopCoroutine("waitseconds");
		StartCoroutine ("waitseconds");
    }

	IEnumerator waitseconds(){
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("06_POTG");
	}
}
