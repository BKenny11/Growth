using UnityEngine;
using System.Collections;

public class Wind : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		// If collision is with the player...
		if (c.gameObject.tag == "Player") {
			Player player = c.gameObject.GetComponent<Player>();
			player.rigidbody2D.AddForce(new Vector2(-10 ,1));
		}
	}
}
