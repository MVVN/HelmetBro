using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetSpawn : MonoBehaviour {

    private GameObject PosTop, PosBot, WhatToSpawnPrefab;
    public int numberOfObjects = 1000;

    // Use this for initialization
    void Start () {
		PosBot = GameObject.Find ("PosBot");
        PosTop = GameObject.Find("PosTop");

		StopCoroutine(SpawnSomethingAwesomePlease());
        StartCoroutine(SpawnSomethingAwesomePlease());
    }

    IEnumerator SpawnSomethingAwesomePlease()                       // IEnumerator für WaitForSeconds benötigt
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            Vector3 Posi = generateRandomPosition();            // generate random position between maximum and minimum on y axis
            Instantiate(WhatToSpawnPrefab, Posi, Quaternion.Euler(0, 0, 0));

            yield return new WaitForSeconds(3);
        }
    }

    Vector3 generateRandomPosition()     // Methode gibt Vector3 zurück
    {
        Vector3 Pos = transform.position;
        Pos.y = Random.Range(PosBot.transform.position.y, PosTop.transform.position.y);
        return Pos;
    }
}
