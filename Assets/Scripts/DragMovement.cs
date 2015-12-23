using UnityEngine;
using System.Collections;

public class DragMovement : MonoBehaviour {

	public float MinPosY = -3;
	public float MaxPosY = 3;
	public float MinPosX = -2;
	public float MaxPosX = 2;
	Vector3 startPos;

	bool isDown = false;
	float timer = 0;
	public float resetTime = 0.2f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown(0)) {
			isDown = true;
			startPos = Input.mousePosition;
			timer = 0;

		} else if (Input.GetMouseButtonUp(0)) {
			isDown = false;
		}

		if (isDown) {

			timer += Time.deltaTime;
			if (timer >= resetTime) {
				startPos = Input.mousePosition;
				timer = 0;
			}

			Vector3 dist = Input.mousePosition - startPos;

			transform.localPosition += ((dist/4)  * Time.deltaTime);

			transform.localPosition = new Vector3 (
				Mathf.Clamp(transform.localPosition.x,MinPosX,MaxPosX),
				Mathf.Clamp(transform.localPosition.y,MinPosY,MaxPosY),
				transform.localPosition.z
			);

			Debug.Log (dist);
		}

	}
}
