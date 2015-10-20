using UnityEngine;

/// <summary>
/// Title screen script
/// </summary>
public class MenuScript : MonoBehaviour
{
	public enum ButtonType { Play, LevelSelect, HowTo, Back, Level1, Level2, Level3, Level4};

	public ButtonType type;
	public GameObject decorationLeft;
	public GameObject decorationRight;

	void Start() {
		decorationLeft.renderer.enabled = false;
		decorationRight.renderer.enabled = false;

	}

	void Update() {
	}
	

	void OnMouseEnter() {
		decorationLeft.renderer.enabled = true;
		decorationRight.renderer.enabled = true;
	}

	void OnMouseExit() {
		decorationLeft.renderer.enabled = false;
		decorationRight.renderer.enabled = false;
	}

	void OnMouseDown() {
		switch(type) {
		case ButtonType.Play:
			Application.LoadLevel("Level1");
			break;
		case ButtonType.LevelSelect:
			Application.LoadLevel("LevelSelect");
			break;
		case ButtonType.HowTo:
			Application.LoadLevel("HowTo");
			break;
		case ButtonType.Back:
			Application.LoadLevel("MainMenu");
			break;
		case ButtonType.Level1:
			Application.LoadLevel("Level1");
			break;
		case ButtonType.Level2:
			Application.LoadLevel("Level2");
			break;
		case ButtonType.Level3:
			Application.LoadLevel("Level3");
			break;
		case ButtonType.Level4:
			Application.LoadLevel("Level4");
			break;
		}
	}
}
