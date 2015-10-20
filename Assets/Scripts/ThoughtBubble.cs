using UnityEngine;
using System.Collections;

public class ThoughtBubble : MonoBehaviour {

	public enum BubbleType {Seedling, Flower, Wilt};

	private Sprite sprite;
	public Sprite hoverSprite;
	public BubbleType type;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer> ().sprite;
		gameObject.transform.position += new Vector3(0.0f, 0.0f, 101.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseEnter() {
		GetComponent<SpriteRenderer> ().sprite = hoverSprite;
	}

	void OnMouseExit() {
		GetComponent<SpriteRenderer> ().sprite = sprite;
	}

	void OnMouseDown() {
		Player temp = GameObject.Find ("Player").GetComponent<Player> ();
		if (type == BubbleType.Seedling) {
			temp.SwitchForm(1);
		}
		else if (type == BubbleType.Flower) {
			temp.SwitchForm(2);
		}
		else {
			temp.SwitchForm(3);
		}
	}
}
