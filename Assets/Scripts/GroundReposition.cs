using UnityEngine;
using System.Collections;

public class GroundReposition : MonoBehaviour {

	public float MinZ = -120f;
	public float NewZ = 89.5f;
	public bool ApplyRotation = true;
	public Transform otherGroundHandler;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.z <= MinZ) {
			transform.position = new Vector3(
				transform.position.x,
				transform.position.y,
				otherGroundHandler.position.z+200//NewZ
				);

			if(ApplyRotation)
			{
				int sign = (Random.value > 0.5f) ? 1 : -1;
				transform.eulerAngles += new Vector3(0,sign * 90,0);
			}
		}
	}
}
