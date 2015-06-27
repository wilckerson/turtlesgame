using UnityEngine;
using System.Collections;

public class PointerMovement : MonoBehaviour
{

	public float MinPosY = -3;
	public float MaxPosY = 3;
	public float MinPosX = -2;
	public float MaxPosX = 2;
	public float zDist = 10f;
	public bool startOnCenter = true;
	private bool centered = false;

	public Vector2 Velocity;

	// Use this for initialization
	void Start ()
	{
	


	}

	Vector3? startInputPos = null;
	float startTime;
	float minSwipeDist = 50.0f;
	float maxSwipeTime = 0.5f;

	// Update is called once per frame
	void Update ()
	{
	

//		var mx = Mathf.Clamp (Input.mousePosition.x / (Screen.width * 1.5f), 0, 1);
//		var my = Mathf.Clamp (Input.mousePosition.y / (Screen.height * 1.5f), 0, 1);
//		
//		var px = MinPosX + ((MaxPosX-MinPosX) * mx);
//		var py = MinPosY + ((MaxPosY-MinPosY) * my); 
//		
//		transform.localPosition = new Vector3 (px, py, transform.localPosition.z);

		var v3 = Input.mousePosition;
		if (startOnCenter && centered == false) {
			v3 = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
			centered = true;
		}
		v3.z = zDist;
		v3 = Camera.main.ScreenToWorldPoint (v3);


		transform.position = new Vector3(
			Mathf.Clamp(v3.x,MinPosX,MaxPosX),
			Mathf.Clamp(v3.y,MinPosY,MaxPosY),
			v3.z
			);

		/*
		if (startInputPos == null && Input.GetMouseButtonDown (0)) {
			startInputPos = Input.mousePosition;
			startTime = Time.time;
			//Debug.Log("MouseDown");
		}

		if (startInputPos != null && Input.GetMouseButtonUp (0)) {

			float gestureTime = Time.time - startTime;
			var gestureDelta = Input.mousePosition - startInputPos.Value;

			//Debug.Log("MOuseUp delta:" + gestureDelta.ToString());

			if (gestureDelta.magnitude > minSwipeDist && gestureTime < maxSwipeTime) {

				var direction = GetDirection (gestureDelta);

				transform.position = new Vector3(
					Mathf.Clamp(transform.position.x + (Velocity.x * direction.x),MinPosX,MaxPosX),
					Mathf.Clamp(transform.position.y + (Velocity.y * direction.y),MinPosY,MaxPosY),
					transform.position.z);
			}

			startInputPos = null;

		}
		*/
	}

	Vector2 GetDirection (Vector2 gestureDelta)
	{
		Vector2 direction = Vector2.zero;

		var angle = Mathf.Rad2Deg * Mathf.Atan2 (gestureDelta.y, gestureDelta.x);
			
		var angleRange = 360f / 16;
			
		//Debug.Log("Angle:" + angle.ToString());
			
		if (angle > -angleRange && angle < angleRange) {
			Debug.Log ("LEFT");
			direction = Vector2.left;
		} else if (angle > angleRange && angle < angleRange * 3) {
			Debug.Log ("UP-LEFT");
			direction = Vector2.up + Vector2.left;
		} else if (angle > angleRange * 3 && angle < angleRange * 5) {
			Debug.Log ("UP");
			direction = Vector2.up;
		} else if (angle > angleRange * 5 && angle < angleRange * 7) {
			Debug.Log ("UP-RIGHT");
			direction = Vector2.up + Vector2.right;
		} else if (angle > angleRange * 7 || angle < -angleRange * 7) {
			Debug.Log ("RIGHT");
			direction = Vector2.right;
		} else if (angle > -angleRange * 7 && angle < -angleRange * 5) {
			Debug.Log ("DOWN-RIGHT");
			direction = Vector2.down + Vector2.right;
		} else if (angle > -angleRange * 5 && angle < -angleRange * 3) {
			Debug.Log ("DOWN");
			direction = Vector2.down;
		} else if (angle > -angleRange * 3 && angle < -angleRange) {
			Debug.Log ("DOWN-LEFT");
			direction = Vector2.down + Vector2.left;
		}

		return direction;
	}

		

}
