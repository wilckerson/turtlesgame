using UnityEngine;
using System.Collections;

public class TouchPad : MonoBehaviour {

	public Transform turn3d;

	public Transform pointer3D;
	public float pointer3dDistX = 3;
	public float pointer3dMinDistY = -3.5f;
	public float pointer3dMaxDistY = 4.5f;

	public RectTransform uiPointer;
	public RectTransform uiPanel;

	public float uiClampMin = -0.8f;
	public float uiClampMax = 0.8f;

	public bool DragOnly = true;

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

					if (!touchOutScreen && DragOnly && !(Vector2.Distance (touchPos, uiPointer.position) <= uiPointer.rect.width / 1.5f)) {
						touchOutScreen = true;
					}
				}

				if (touchOutScreen) {
					isDown = false;
				}


			} 
		} else {
			touchPos = Input.mousePosition;

			if (Input.GetMouseButtonDown (0) && touchPos.y <= (Screen.height/2)) {

				if (DragOnly){

					if (Vector2.Distance(touchPos,uiPointer.position) <= uiPointer.rect.width/1.5f) {

						isDown = true;
					}

				} else {
					
					isDown = true;
				}
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

			var clampY = (axis.y / uiClampMax);

			var distY = Mathf.Abs(clampY) * (clampY > 0 ? pointer3dMaxDistY : pointer3dMinDistY);


			
			if (turn3d != null) {
				turn3d.Rotate (new Vector3 (0, axis.x * 2, 0));
				//Vector3 RIGHT = turn3d.TransformDirection(Vector3.right);
				//Vector3 FORWARD = turn3d.TransformDirection(Vector3.forward);

				//turn3d.localPosition += RIGHT * axis.x;
				//turn3d.localPosition += FORWARD * axis.y;

				turn3d.position += turn3d.up * Time.deltaTime * (40 * axis.y);
			} else {
				pointer3D.position = new Vector3 (
					pointer3dDistX * (axis.x/uiClampMax),
					distY,
					pointer3D.position.z);
			}
		}
		if (turn3d != null) {
			turn3d.position += turn3d.forward * Time.deltaTime * 30;
		}

		//Debug.Log(isDown);
	}
}
