using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class POTG_SionVideo : MonoBehaviour {
    public RawImage myImage;
    private bool introFinished = false;

    void Start () {		
		StartCoroutine ("waitForIntro");
	}

    void Update() {
        if (introFinished) {
            Destroy(myImage);
        }
    }

    IEnumerator waitForIntro(){		
		yield return new WaitForSeconds (5.8f);
		introFinished = true;
		StopCoroutine ("waitForIntro");
	}

	}

