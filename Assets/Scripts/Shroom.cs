using UnityEngine;
using System.Collections;

public class Shroom : MonoBehaviour {

    public Rigidbody2D rb;
	public float speed = 7f;
    public GameObject PosLeft;
	private HealthManager healthManager;


    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        PosLeft = GameObject.Find("PosLeft");
		healthManager = FindObjectOfType<HealthManager> ();
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 Force = new Vector2(-speed, 0);
        //rb.velocity = Force;
		transform.Translate(Force * Time.deltaTime);

        if (transform.position.x < PosLeft.transform.position.x)
        {
            Destroy(gameObject);
        }      
    }     
    
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.name == "Player") {
			healthManager.RemoveHealth ();
			Destroy(gameObject);
		}
    }     
}
