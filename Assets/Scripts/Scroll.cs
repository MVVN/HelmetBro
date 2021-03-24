using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
	public static Scroll instance;
	public bool scrolling;
	public float speed = 0.385f;
    new Renderer renderer;

	// Use this for initialization
	void Start () {
		Scroll.instance = this;
		renderer = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (scrolling) {
			Vector2 offset = new Vector2 (Time.time * speed, 0f);
			renderer.material.mainTextureOffset = offset;
			PlayerPrefs.SetFloat ("Offset", offset.x);
		}
	}
}
