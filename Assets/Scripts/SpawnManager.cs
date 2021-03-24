using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{	
    public static SpawnManager instance;
	private GameObject PosTop, PosBot;
	public GameObject[] WhatToSpawn;

	void Start () {
		SpawnManager.instance = this;

		PosBot = GameObject.Find("PosBot");
		PosTop = GameObject.Find("PosTop");
	
		StopCoroutine("SpawnSomethingAwesomePlease");
		StartCoroutine("SpawnSomethingAwesomePlease");
	}

	IEnumerator SpawnSomethingAwesomePlease()                       // IEnumerator für WaitForSeconds benötigt
	{
		while (true)                   // while schleife für Unendlichkeit mit boolean zb. while (playing)   playing = true dann immer pilze spawnen
		{
			Vector3 Posi = generateRandomPosition();
			Instantiate(WhatToSpawn[Random.Range(0, WhatToSpawn.Length)], Posi, Quaternion.Euler(0, 0, 0));
			yield return new WaitForSeconds(Random.Range(1f, 2.5f));
		}
	}

	Vector3 generateRandomPosition()     // Methode gibt Vector3 zurück
	{
		Vector3 Pos = transform.position;
		Pos.y = Random.Range(PosBot.transform.position.y, PosTop.transform.position.y);
		return Pos;
	}
}
