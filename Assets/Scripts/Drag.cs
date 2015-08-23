using UnityEngine;
using System.Collections;

public class Drag : MonoBehaviour {

	public float zDist = 30;
	public Vector3 point;

	public GameObject Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDrag(){

		if (Input.GetMouseButton (0)) {
			var pointerPos = new Vector3 (
			Mathf.Clamp (Input.mousePosition.x, 0, Screen.width),
			Mathf.Clamp (Input.mousePosition.y, 0, Screen.height / 2),
			Camera.main.nearClipPlane * zDist);

			var targetPos = new Vector3 (
			pointerPos.x,
			pointerPos.y + (Screen.height / 2),
			Camera.main.nearClipPlane * zDist);


			transform.position = Camera.main.ScreenToWorldPoint (pointerPos);

			Target.transform.position = Camera.main.ScreenToWorldPoint (targetPos);
			Debug.Log (Target.transform.position);
		}
	}
}
