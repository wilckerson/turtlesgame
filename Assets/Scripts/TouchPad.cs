using UnityEngine;
using System.Collections;

public class TouchPad : MonoBehaviour {

	public Transform pointer3D;
	public float pointer3dDistX = 3;
	public float pointer3dDistY = 3;

	public RectTransform uiPointer;
	public RectTransform uiPanel;

	public float uiClampMin = -0.8f;
	public float uiClampMax = 0.8f;

	bool isDown = false;
	bool touchOutScreen = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 touchPos = Vector2.zero;

		if (Input.touchSupported) {
			isDown = false;

			if (Input.touchCount > 0) {
				isDown = true;
				var touch = Input.touches [0];

				touchPos = touch.position;

				if (touch.phase == TouchPhase.Began) {
					
					touchOutScreen = touchPos.y >= (Screen.height / 2);
				}

				if (touchOutScreen) {
					isDown = false;
				}
			} 
		} else {
			touchPos = Input.mousePosition;

			if (Input.GetMouseButtonDown (0) && touchPos.y <= (Screen.height/2)) {
				isDown = true;
			} else if (Input.GetMouseButtonUp (0)) {
				isDown = false;
			}
		}


			
		/*
		var touchPos = Input.mousePosition;

		if (Input.GetMouseButtonDown (0) && touchPos.y <= (Screen.height/2)) {
			isDown = true;
		} else if (Input.GetMouseButtonUp (0)) {
			isDown = false;
		}
		*/

		if (isDown) {
			var axis = new Vector3 (
				Mathf.Clamp ((touchPos.x / Screen.width) * 2 - 1, uiClampMin, uiClampMax),
				Mathf.Clamp ((touchPos.y / Screen.height) * 4 - 1, uiClampMin, uiClampMax),
				          0);


			uiPointer.localPosition = new Vector2 (
				(uiPanel.rect.width / 2) * axis.x,
				(uiPanel.rect.height / 2) * axis.y
			);

			pointer3D.position = new Vector3 (
				pointer3dDistX * (axis.x/uiClampMax),
				pointer3dDistY * (axis.y/uiClampMax),
				0);
		}

		//Debug.Log(isDown);
	}
}
