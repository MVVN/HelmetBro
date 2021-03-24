using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public Rigidbody2D rb;
	public float speed = 7f;
    public GameObject PosLeft;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        PosLeft = GameObject.Find("PosLeft");		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 Force = new Vector2(-speed, 0);
        //rb.velocity = Force;
		transform.Translate(Force * Time.deltaTime);

        if(transform.position.x < PosLeft.transform.position.x)
        {
            Destroy(gameObject);
        }		
	}

	void OnTriggerEnter2D(Collider2D other){	
		if (other.gameObject.name == "Player") {
			Destroy (gameObject);
		}
	}
}
