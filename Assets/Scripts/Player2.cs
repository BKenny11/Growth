using UnityEngine;
using System.Collections;

public class Player2 : MonoBehaviour {

	public float jumpForce = 50.0f; // force applied vertically when the player jumps.
	public float moveForce = 350.0f; // movement speed
	public float maxSpeed = 7.0f; // maximum movement speed
	public int sunshards = 0; // number of pickups the player is holding
	public bool hasDoubleJump = false; // Boolean of weather player can do a double jump
	public bool doubleJumpLock = false;
	private bool facingRight = true; // flagged true if the player is facing right
	public bool canJump = false; //Test Boolean to try and get the infinite jumps fixed
	private bool jump; // flagged true if the player will jump next fixed fram
	public bool inPlanter = false; //check to see if the player is inside the planter
	public float GroundDistance; // maybe useful in the future??
	public float form = 1; //Keeps track of what for the player is currently in
	public bool canTransform = false;
	public bool downPressed = false;
	public GameObject seedlingThoughtBubble;
	public GameObject flowerThoughtBubble;
	public GameObject wiltThoughtBubble;
	private bool transforming = false;
	                                                     
	private Animator animator;
	//Set these in Unity Game sidebar
	public Sprite sprite1; //sprite for form 1
	public Sprite sprite2; //sprite for form 2
	public Sprite sprite3; //sprite for form 3
	SpriteRenderer sprite;

	void Start () {
		sprite = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
		animator = GetComponent<Animator> ();
		if (sprite.sprite == null) // if the sprite on spriteRenderer is null then
			sprite.sprite = sprite1; 
	}
	
	// Update is called once per frame
	void Update () {
		// if the player is grounded and presses the jump button...
		if (Input.GetButtonDown ("Jump") && rigidbody2D.velocity.y==0) {
			jump = true; // flag them to jump next frame
			//canJump = false;
		}
		if (Input.GetButtonDown ("Jump") && hasDoubleJump && rigidbody2D.velocity.y != 0 && form ==2) {
			jump = true; // flag them to jump next frame
			hasDoubleJump = false;
			doubleJumpLock = true;
		}

		// in Edit > Project Settings > Input, make sure you rename an input to be "Root"
		if (Input.GetButtonDown ("Root") && form ==3) {
			rigidbody2D.mass = 500; // Prevents plant from moving when rooted
		}

		if (Input.GetButtonUp ("Root") && form == 3) {
			rigidbody2D.mass = 1; //Allows movement again, when the player lets up on the Rooted button
		}


		//When the Player presses "1" when in the planter, it changes to form1
		if (Input.GetButtonDown("Fire1") && inPlanter == true){
			canTransform = true;
		}
		if (Input.GetButtonUp("Fire1")){
			canTransform = false;

		}

		if(rigidbody2D.velocity.y == 0)
		{
			doubleJumpLock = false;
		}

		if (!transforming) {
			Animations ();
		}
	}

	// FixedUpdate is called at fixed time intervals
	void FixedUpdate() {

		float h = Input.GetAxis ("Horizontal"); // cache horizontal input

			// if player is changing direction or hasn't reached speed cap yet...
			if (h * rigidbody2D.velocity.x < maxSpeed) {
					rigidbody2D.AddForce (Vector2.right * h * moveForce); // apply horizontal force
			}

			// if player's horizontal speed is greater than the speed cap...
			if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed) {
				// enforce the speed cap
				rigidbody2D.velocity = new Vector2(Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
			}

			// check if player is switching directions...
			if (h > 0 && !facingRight) {
				Flip ();
			}
			else if (h < 0 && facingRight) {
				Flip ();
			}

		// if the player is jumping this frame...
		if (jump) {
			rigidbody2D.AddForce(Vector2.up * jumpForce); // apply upwards force
			jump = false; // reset jump flag
		}
	}

	// Flip the direction the player is facing
	void Flip () {
		facingRight = !facingRight; // flip flag
		Vector3 ls = transform.localScale; // cache current scale
		ls.x *= -1; // flip horizontally
		transform.localScale = ls; // maintain scale
	}

	// Called when this collides with another 2D collider
	void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag == "PlantPot" && transform.position.y > 3) {
			if(seedlingThoughtBubble.transform.position.z > 0) {
				seedlingThoughtBubble.transform.position -= new Vector3(0.0f, 0.0f, 101.0f);
				flowerThoughtBubble.transform.position -= new Vector3(0.0f, 0.0f, 101.0f);
				wiltThoughtBubble.transform.position -= new Vector3(0.0f, 0.0f, 101.0f);
			}
		}
	}

	void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag == "PlantPot") {
			if(seedlingThoughtBubble.transform.position.z == 0) {
				seedlingThoughtBubble.transform.position += new Vector3(0.0f, 0.0f, 101.0f);
				flowerThoughtBubble.transform.position += new Vector3(0.0f, 0.0f, 101.0f);
				wiltThoughtBubble.transform.position += new Vector3(0.0f, 0.0f, 101.0f);
			}
		}
	}

	public void SwitchForm(int selectedForm) {
		if (form != selectedForm) {
			if(selectedForm == 1) {
				if(form == 2) {
					animator.Play("FlowerToSeedlingBury");
				}
				else {
					animator.Play("WiltToSeedlingBury");
				}

				SetForm (1);
			}
			else if(selectedForm == 2) {
				if(form == 1) {
					animator.Play("SeedlingToFlowerBury");
				}
				else {
					animator.Play("WiltToFlowerBury");
				}

				SetForm (2);
			}
			else {
				if(form == 1) {
					animator.Play("SeedlingToWiltBury");
				}
				else {
					animator.Play("FlowerToWiltBury");
				}

				SetForm (3);
			}
		}
	}

	public void SetForm(int n) {
		if (n == 1) {
			form = 1;
			moveForce = 350;
			maxSpeed = 7.0f;
		} 
		else if (n == 2) {
			form = 2;
			moveForce = 150;
			maxSpeed = 5.0f;
		} 
		else {
			form = 3;
			moveForce = 150;
			maxSpeed = 5.0f;
		}
	}

	public void Animations() {
		if (form == 1) {
			if (rigidbody2D.velocity.y > .001 || rigidbody2D.velocity.y < -.001) {
				animator.SetInteger ("AnimState", 2);
			} else if (rigidbody2D.velocity.x != 0) {
				animator.SetInteger ("AnimState", 1);
			} else {
				animator.SetInteger ("AnimState", 0);
			}

		} else if (form == 2) {
			if (rigidbody2D.velocity.y > .001 || rigidbody2D.velocity.y < -.001) {
				animator.SetInteger ("AnimState", 5);
			} else if (rigidbody2D.velocity.x != 0) {
				animator.SetInteger ("AnimState", 4);
			} else {
				animator.SetInteger ("AnimState", 3);
			}
		} else if (form == 3) {
			if (rigidbody2D.velocity.y > .001 || rigidbody2D.velocity.y < -.001) {
				animator.SetInteger ("AnimState", 8);
			} else if (rigidbody2D.velocity.x != 0) {
				animator.SetInteger ("AnimState", 7);
			} else {
				animator.SetInteger ("AnimState", 6);
			}
		}
	}
}
