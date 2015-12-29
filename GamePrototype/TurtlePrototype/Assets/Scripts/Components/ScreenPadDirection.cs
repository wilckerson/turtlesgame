using UnityEngine;
using System.Collections;

public class ScreenPadDirection : MonoBehaviour {

	public float percentageX = 0.8f;
	public float percentageY = 0.7f;

	Vector2 touchPos;
	Vector2 direction;
	bool isDown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.touchSupported) {
			isDown = false;

			if (Input.touchCount > 0) {
				isDown = true;
				touchPos = Input.touches [0].position;
			}
		} else {
			touchPos = Input.mousePosition;

			if (Input.GetMouseButtonDown (0)) {
				isDown = true;
			} else if (Input.GetMouseButtonUp (0)) {
				isDown = false;
			}
		}

		if (isDown) {


			direction = new Vector2 (
				Mathf.Clamp ((touchPos.x - (Screen.width/2))/((Screen.width/2) * percentageX), -1, 1),
				Mathf.Clamp ((touchPos.y - (Screen.height/2))/((Screen.height/2) * percentageY), -1, 1)
			);

			//Debug.Log (string.Format ("ScreePadDirection: {0}", direction));
		}
	}

	public Vector2 GetDirection(){
		return direction;
	}

	public Vector2 getTouchPos(){
		return touchPos;
	}
}
