using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public static PlayerMovement instance;

	private GameObject minY, maxY, Level1, Level2, Level3;
	private int curLevel = 1;
	public float speed = 7f;
	private float xOffset = 0.0f;
	public DeathManager deathManager;
	public AudioSource teemoLaugh;
	public AudioSource trap;
	// Use this for initialization
	void Start () {
		PlayerMovement.instance = this;

		Level1 = GameObject.Find ("Level1");
		Level2 = GameObject.Find ("Level2");
		Level3 = GameObject.Find ("Level3");
		maxY = GameObject.Find ("PosTop");
		minY = GameObject.Find ("PosBot");

		transform.position = new Vector3 (Level1.transform.position.x, -1f, 0f);		// player starts at first level
	}

       // Update is called once per frame
    void Update () {
		float moveY = 0;

		if (xOffset < 0) {			
			if (transform.position.x <= Level2.transform.position.x && curLevel == 2) {
				xOffset = 0;
				Vector2 temp = transform.position;
				temp.x = Level2.transform.position.x;
				transform.position = temp;
			}
			if (transform.position.x <= Level3.transform.position.x && curLevel == 3) {
				xOffset = 0;
				Vector2 temp = transform.position;
				temp.x = Level3.transform.position.x;
				transform.position = temp;
			}
		} else if (xOffset > 0) {
			if (transform.position.x >= Level2.transform.position.x && curLevel == 2) {
				xOffset = 0;
				Vector2 temp = transform.position;
				temp.x = Level2.transform.position.x;
				transform.position = temp;
			}
			if (transform.position.x >= Level1.transform.position.x && curLevel == 1) {
				xOffset = 0;
				Vector2 temp = transform.position;
				temp.x = Level1.transform.position.x;
				transform.position = temp;
			}		
		}else {
			moveY = Input.GetAxis ("Vertical") * Time.deltaTime * speed;

			Vector3 myPos = transform.position;

			if (transform.position.y < minY.transform.position.y){
				myPos.y = minY.transform.position.y;
				transform.position = myPos;			
			}
			if (transform.position.y > maxY.transform.position.y) {
				myPos.y = maxY.transform.position.y;
				transform.position = myPos;
			}		
		
		}
		transform.Translate (xOffset * Time.deltaTime, moveY, 0);
	}
 
    void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.tag == "Shroom")
        {
			teemoLaugh.Play(0);
			StopCoroutine (ShroomEffect());
			StartCoroutine (ShroomEffect());
        }
		if (Object.tag == "Trap")
        {
			TrapEffect();
        } 
    }    

	IEnumerator ShroomEffect()		// shroom slows 
	{  
		speed = speed * 0.5f;
		yield return new WaitForSeconds (6);
		speed = speed / 0.5f; 
    }

	void TrapEffect()		// trap forces player to get up in level (closer to enemy follower)
    {
		trap.Play (0);
		float curPos = transform.position.x;

		if (curPos == Level1.transform.position.x) {
			curLevel = 2;
			xOffset = -2 ;
		}
		if (curPos == Level2.transform.position.x) {
			curLevel = 3;
			xOffset = -2 ;
		}
		if (curPos == Level3.transform.position.x) {
			deathManager.death ();
		}
    }

	public void levelUp()
	{
		float curPos = transform.position.x;

		if (curPos == Level3.transform.position.x) {
			curLevel = 2;
			xOffset = +2; 
			}

		if (curPos == Level2.transform.position.x) {
			curLevel = 1;
			xOffset = +2;
			}
	}
}


