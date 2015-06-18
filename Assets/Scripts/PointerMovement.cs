using UnityEngine;
using System.Collections;

public class PointerMovement : MonoBehaviour {

	public float MinPosY = -3;
	public float MaxPosY = 3;
	public float MinPosX = -2;
	public float MaxPosX = 2;

	public float zDist = 10f;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {
	

//		var mx = Mathf.Clamp (Input.mousePosition.x / (Screen.width * 1.5f), 0, 1);
//		var my = Mathf.Clamp (Input.mousePosition.y / (Screen.height * 1.5f), 0, 1);
//		
//		var px = MinPosX + ((MaxPosX-MinPosX) * mx);
//		var py = MinPosY + ((MaxPosY-MinPosY) * my); 
//		
//		transform.localPosition = new Vector3 (px, py, transform.localPosition.z);

		var v3 = Input.mousePosition;
		v3.z = zDist;
		v3 = Camera.main.ScreenToWorldPoint(v3);



		transform.position = new Vector3(
			Mathf.Clamp(v3.x,MinPosX,MaxPosX),
			Mathf.Clamp(v3.y,MinPosY,MaxPosY),
			v3.z
			);

	}
}
