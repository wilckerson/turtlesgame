using UnityEngine;
using System.Collections;

public class TurnAround : MonoBehaviour {

	public float RotationX = 10;
	public float RotationY = 10;
	public float RotationZ = 10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
//		transform.rotation = Quaternion.Euler(
//			transform.eulerAngles.x + RotationX,
//			transform.eulerAngles.y + RotationY,
//			transform.eulerAngles.z + RotationZ);


		transform.Rotate (RotationX, RotationY, RotationZ,Space.World);

		/*
		transform.eulerAngles += new Vector3 (
			RotationX * Time.deltaTime,
			RotationY * Time.deltaTime,
			RotationZ * Time.deltaTime);
			*/
	}
}
