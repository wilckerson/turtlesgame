using UnityEngine;
using System.Collections;

public class HalfScreenDirection : MonoBehaviour {


	Vector2 direction;
	public bool KeyboardFallback = false;
	public bool ConsoleDebug = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		direction = Vector2.zero;

		if (Input.GetMouseButton (0)) {

			if (Input.mousePosition.x < (Screen.width / 2)) {
				direction = Vector2.left;
			} else {
				direction = Vector2.right;
			}
		}

		if (KeyboardFallback) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				direction = Vector2.left;

			} else if (Input.GetKey (KeyCode.RightArrow)) {
				direction = Vector2.right;
			}
		}

		if (ConsoleDebug) {
			Debug.Log (string.Format ("HalfScreenDirection: {0}", direction));
		}

	}

	public Vector2 GetDirection(){
		return direction;
	}
}
