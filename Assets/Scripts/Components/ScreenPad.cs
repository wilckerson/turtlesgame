using UnityEngine;
using System.Collections;

public class ScreenPad : MonoBehaviour {

	public Transform target;
	public float turnVelocityX = 2;
	public float turnVelocityY = 2;

	bool isDown = false;
	Vector3 rotation = Vector3.zero;

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

			var t = (target != null) ? target : transform;
			var coordinates2D = Camera.main.WorldToScreenPoint (t.position);

			//var dirX = (Input.mousePosition.x > coordinates2D.x) ? 1 : -1;
			//var dirY = (Input.mousePosition.y > coordinates2D.y) ? -1 : 1;

			var dirX = Mathf.Clamp( (touchPos.x - coordinates2D.x) / (Screen.width/3),-1,1);
			var dirY = Mathf.Clamp((coordinates2D.y - touchPos.y) / (Screen.width/3),-1,1);

			Debug.Log (string.Format ("dX: {0} dy: {1}", dirX, dirY));

			//transform.Rotate (dirY * turnVelocityX * Time.deltaTime, 0, 0);
			transform.Rotate (0,dirX * turnVelocityY * Time.deltaTime, 0,Space.World);

//			var ray = Camera.main.ScreenPointToRay(touchPos);
//			var p = ray.GetPoint (100);
//			transform.LookAt(p);


//			Plane plane = new Plane(Vector3.up, transform.position + new Vector3(0,0,10));
//			var ray = Camera.main.ScreenPointToRay(touchPos);
//			float dist = 0;
//			plane.Raycast(ray, out dist);
//			transform.LookAt(ray.GetPoint(dist));


		}

		if (Input.GetKey (KeyCode.UpArrow)) {
			transform.Rotate (-turnVelocityX * Time.deltaTime, 0, 0);
		}else if (Input.GetKey (KeyCode.DownArrow)) {
			transform.Rotate (turnVelocityX * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			transform.Rotate (0,turnVelocityY* Time.deltaTime, 0,Space.World);
		}else if (Input.GetKey (KeyCode.LeftArrow)) {
			transform.Rotate (0,-turnVelocityY* Time.deltaTime, 0,Space.World);
		}
	}
}
