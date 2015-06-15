using UnityEngine;
using System.Collections;

public class TurtleMovement : MonoBehaviour {

	public float MinPosY = -3;
	public float MaxPosY = 3;
	public float MinPosX = -2;
	public float MaxPosX = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		var mx = Mathf.Clamp (Input.mousePosition.x / Screen.width, 0, 1);
		var my = Mathf.Clamp (Input.mousePosition.y / Screen.height, 0, 1);
		
		var px = MinPosX + (2 * MaxPosX * mx);
		var py = MinPosY + (2 * MaxPosY * my); 
		
		transform.localPosition = new Vector3 (px, py, transform.localPosition.z);

	}
}
