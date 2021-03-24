using UnityEngine;
using System.Collections;


// Sion (Enemy) follows player
public class EnemyFollow : MonoBehaviour {

	public GameObject target;
	private float speed = 5.5f;    

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (-9, -1, 0);
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 targetPos = target.transform.position;
		targetPos.x = transform.position.x;
		targetPos.z = transform.position.z;
		transform.position = Vector3.Lerp (transform.position, targetPos, Time.deltaTime * speed);
	}
}
