using UnityEngine;
using System.Collections;

public enum TouchPadMode{
	Click,
	Drag,
	DragRelative,
	Mixed
}

public class TouchPadFull : MonoBehaviour {

	public float touchSizePercentage = 0.2f;

	public float pointer3dDistX = 3;
	public float pointer3dDistY = 3;
	//public float pointer3dMinDistY = -3.5f;
	//public float pointer3dMaxDistY = 4.5f;

	public float uiClampX = 0.7f;
	public float uiClampY = 0.6f;

	//public bool DragOnly = true;
	//public bool ClickOnly = false;
	public TouchPadMode PadMode =  TouchPadMode.Mixed;

	bool isDown = false;
	bool touchOutScreen = false;
	Vector2 startDownScreenPos;
	Vector3 startDownObjPos;
	bool canMove = true;

	// Use this for initialization
	void Start () {
	
	}

//	void OnDisable() {
//		isDown = false;
//	}


	// Update is called once per frame
	void Update () {
		var touchSize = Screen.width * touchSizePercentage;
		Vector2 touchPos = Vector2.zero;
		if (PadMode == TouchPadMode.Click) {

			if (Input.touchSupported) {
				
				if (Input.touchCount > 0) {
					var touch = Input.touches [0];
					touchPos = touch.position;
				}
			} else {
				touchPos = Input.mousePosition;
			}

			if (Input.GetMouseButtonDown (0)) {
				var axis = new Vector3 (
					           Mathf.Clamp ((touchPos.x / Screen.width) * 2 - 1, -uiClampX, uiClampX),
					           Mathf.Clamp ((touchPos.y / Screen.height) * 2 - 1, -uiClampY, uiClampY),
					           0);

				transform.position = new Vector3 (
					pointer3dDistX * (axis.x / uiClampX),
					pointer3dDistY * (axis.y / uiClampY),
					transform.position.z);
			}

		}else if(PadMode == TouchPadMode.DragRelative){

			if (Input.GetMouseButtonDown (0)) {
				startDownScreenPos = Input.mousePosition;
				startDownObjPos = transform.position;
				isDown = true;
			
			} else if (Input.GetMouseButtonUp (0)) {
				isDown = false;
			}

			if (!canMove) {
				startDownObjPos = transform.position;
			}

			if (isDown && canMove) {
				Vector2 currentPos = Input.mousePosition;
					
				if (Input.touchSupported) {

					if (Input.touchCount > 0) {
						var touch = Input.touches [0];
						currentPos = touch.position;
					}
				}

				Vector2 percentPos = new Vector2 (
					(currentPos.x - startDownScreenPos.x)/((Screen.width*uiClampX)/2),
					(currentPos.y-startDownScreenPos.y)/((Screen.height*uiClampY)/2)
				);

				transform.position = startDownObjPos + new Vector3 (
					pointer3dDistX * percentPos.x,
					pointer3dDistY * percentPos.y,
					0);
				
				transform.position = new Vector3 (
					Mathf.Clamp(transform.position.x,-pointer3dDistX,pointer3dDistX),
					Mathf.Clamp(transform.position.y,-pointer3dDistY,pointer3dDistY),
					transform.position.z
				);

			}

		} else {
			if (Input.touchSupported) {
				isDown = false;

				if (Input.touchCount > 0) {
					isDown = true;
					var touch = Input.touches [0];

					touchPos = touch.position;

					if (touch.phase == TouchPhase.Began) {
					
						if (PadMode == TouchPadMode.Drag && Vector2.Distance (touchPos, Camera.main.WorldToScreenPoint (transform.position)) > touchSize) {

							touchOutScreen = true;

						}
					}

					if (touchOutScreen) {
						isDown = false;
					}


				} 
			} else {
				touchPos = Input.mousePosition;

				if (Input.GetMouseButtonDown (0)) {

					isDown = true;

					if (PadMode == TouchPadMode.Drag && Vector2.Distance (touchPos, Camera.main.WorldToScreenPoint (transform.position)) > touchSize) {

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
					pointer3dDistX * (axis.x / uiClampX),
					pointer3dDistY * (axis.y / uiClampY),
					transform.position.z);
			
			}
		}
	}

	public void SetCanMove(bool canMove){
		this.canMove = canMove;
	}
}
