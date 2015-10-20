using UnityEngine;
using System.Collections;

public class DoubleJump : MonoBehaviour {
	Player player;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		player = c.gameObject.GetComponent<Player> ();
		// If collision is with the player...
		if (c.gameObject.tag == "Player") {

			player.hasDoubleJump = true;
		}


	}
}
