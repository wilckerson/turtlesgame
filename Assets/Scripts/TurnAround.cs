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
	
		transform.eulerAngles += new Vector3 (
			RotationX * Time.deltaTime,
			RotationY * Time.deltaTime,
			RotationZ * Time.deltaTime);
	}
}
