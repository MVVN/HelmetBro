using UnityEngine;
using System.Collections;

public class HelmetScript : MonoBehaviour {
	public int scoreToGive;
	public float speed = 7f;
	public int scoreToSub;
	private Rigidbody2D rb;
	public GameObject PosLeft;
	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
		theScoreManager = FindObjectOfType<ScoreManager> ();
		PosLeft = GameObject.Find("PosLeft");
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 Force = new Vector2(-speed, 0);
		transform.Translate(Force * Time.deltaTime);

		if (transform.position.x < PosLeft.transform.position.x)
		{
			Destroy(gameObject);
		}      
	}     

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.gameObject.name == "Player")
		{
			theScoreManager.AddScore(scoreToGive);
			theScoreManager.SubHealthScore(scoreToSub);
			Destroy(gameObject);
		}
	}
}
