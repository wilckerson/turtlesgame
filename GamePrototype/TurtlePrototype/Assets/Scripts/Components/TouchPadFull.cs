using UnityEngine;
using System.Collections;

public class TouchPadFull : MonoBehaviour {

	public float touchSizePercentage = 0.2f;

	public float pointer3dDistX = 3;
	public float pointer3dDistY = 3;
	//public float pointer3dMinDistY = -3.5f;
	//public float pointer3dMaxDistY = 4.5f;

	public float uiClampX = 0.7f;
	public float uiClampY = 0.6f;

	public bool DragOnly = true;

	bool isDown = false;
	bool touchOutScreen = false;
	// Use this for initialization
	void Start () {
	
	}


	// Update is called once per frame
	void Update () {
		var touchSize = Screen.width * touchSizePercentage;
		Vector2 touchPos = Vector2.zero;

		if (Input.touchSupported) {
			isDown = false;

			if (Input.touchCount > 0) {
				isDown = true;
				var touch = Input.touches [0];

				touchPos = touch.position;

				if (touch.phase == TouchPhase.Began) {
					
					if (DragOnly && Vector2.Distance(touchPos,Camera.main.WorldToScreenPoint (transform.position)) > touchSize) {

						touchOutScreen = true;

					}
				}

				if (touchOutScreen) {
					isDown = false;
				}


			} 
		} else {
			touchPos = Input.mousePosition;

			if (Input.GetMouseButtonDown(0)) {

				isDown = true;

				if (DragOnly && Vector2.Distance(touchPos,Camera.main.WorldToScreenPoint (transform.position)) > touchSize) {

						isDown = false;

				}
			} else if (Input.GetMouseButtonUp (0)) {
				isDown = false;
			}
		}

		if (isDown) {
			var axis = new Vector3 (
				Mathf.Clamp ((touchPos.x / Screen.width) * 2 - 1, -uiClampX, uiClampX),
				Mathf.Clamp ((touchPos.y / Screen.height) * 2 - 1, -uiClampY, uiClampY),
				          0);
			
			transform.position = new Vector3 (
				pointer3dDistX * (axis.x/uiClampX),
				pointer3dDistY * (axis.y/uiClampY),
				transform.position.z);
			
		}
	}
}
