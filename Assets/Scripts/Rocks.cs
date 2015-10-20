using UnityEngine;
using System.Collections;

public class Rocks : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D col) { 
		
		
				if (col.transform.tag == "Player") { 
						Player player = col.gameObject.GetComponent<Player> ();
						player.maxSpeed = 0;
						StartCoroutine(Collided(player));
						
				}
			if (col.transform.tag == "Ground") { 
				
				StartCoroutine(CollidedG());
			
			}	
		
		}
		

		IEnumerator Collided(Player p){


						yield return new WaitForSeconds (1.0f);
						Destroy (gameObject);
						Player player = p.gameObject.GetComponent<Player> ();
						player.maxSpeed = 5;

		}


	IEnumerator CollidedG(){

			
			yield return new WaitForSeconds (1.0f);
			Destroy (gameObject);
		}	

	

}
