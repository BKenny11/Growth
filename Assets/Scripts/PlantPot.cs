using UnityEngine;
using System.Collections;

public class PlantPot : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D c)
	{
		// If collision is with the player
		if (c.tag == "Player") {
						Player player = c.gameObject.GetComponent<Player> ();
						player.inPlanter = true;

				}
		if (c.tag == "Player") { 
			Player player = c.gameObject.GetComponent<Player> ();
			if (player.downPressed == false) {
				transform.collider2D.isTrigger = false;
			}
		}
	}


	void OnCollisionEnter2D(Collision2D col) { 
				

			if (col.transform.tag == "Player") { 
						Player player = col.gameObject.GetComponent<Player> ();
						if (player.downPressed == true) {
							Debug.Log("oh hey");
							transform.collider2D.isTrigger = true;
						}
				}



	

		}
}


