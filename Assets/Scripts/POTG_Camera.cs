using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POTG_Camera : MonoBehaviour {

	public GameObject sion;
	private Vector3 offset;

	void LateUpdate (){
		transform.position = sion.transform.position + new Vector3(0.5f,0,-1);
	}
}