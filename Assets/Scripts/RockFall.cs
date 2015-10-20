using UnityEngine;
using System.Collections;

public class RockFall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	
	void OnCollisionEnter2D(Collision2D col) { 
		
		
		if (col.transform.tag == "Player") { 
			//Player player = col.gameObject.GetComponent<Player> ();
			transform.collider2D.isTrigger = true;

		}
		
		
		
		
		
	}
}
