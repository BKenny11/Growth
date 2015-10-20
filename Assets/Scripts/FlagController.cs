//Add to Flags
//Add BoxCollider
//Set Box collider to trigger
//set "Level2" to the name of the next Level
//Make sure you add all the levels in the build settings


using UnityEngine;
using System.Collections;

public class FlagController : MonoBehaviour {
	public string levelname = "Level2";
	public int requiredShards = 3;
	Player PLAYER;
	private int playerShards;
	SpriteRenderer sr;
	public Sprite CompletedSprite;

	// Use this for initialization
	void Start () {

		PLAYER = GameObject.FindGameObjectWithTag("Player").GetComponent<Player> ();
		sr = GetComponent < SpriteRenderer >();

	}
	
	// Update is called once per frame
	void Update () {

		if (PLAYER.sunshards == requiredShards) {
			sr.sprite = CompletedSprite;
		}

	}

	// Called when this collides with another 2D collider
	void OnTriggerEnter2D(Collider2D c)
	{
		// If collision is with the player...
		if (c.tag == "Player") {
			Player player = c.gameObject.GetComponent<Player>();
			if (player.sunshards >= requiredShards)
			{

				Application.LoadLevel(levelname);
			}
		}
	}
}
