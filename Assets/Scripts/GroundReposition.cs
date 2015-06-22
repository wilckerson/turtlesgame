using UnityEngine;
using System.Collections;

public class GroundReposition : MonoBehaviour {


	public float MinZ = -300;
	public bool ApplyRotation = true;
	//public float Velocity = 100;

	public Transform GroundA;
	public Transform GroundB;

	private float Size = 0;

	// Use this for initialization
	void Start () {
	
		Size = GroundA.position.z - GroundB.position.z;
	}
	
	// Update is called once per frame
	void Update () {
	
		//GroundA.position += new Vector3 (0, 0, -Velocity * Time.deltaTime);
		//GroundB.position += new Vector3 (0, 0, -Velocity * Time.deltaTime);

		if (GroundA.position.z <= MinZ) {
			GroundA.position = GroundB.position + new Vector3(0,0,Size);

			if(ApplyRotation)
			{
				int sign = (Random.value > 0.5f) ? 1 : -1;
				GroundA.eulerAngles += new Vector3(0,sign * 90,0);
			}
		}

		if (GroundB.position.z <= MinZ) {
			GroundB.position = GroundA.position + new Vector3(0,0,Size);

			if(ApplyRotation)
			{
				int sign = (Random.value > 0.5f) ? 1 : -1;
				GroundB.eulerAngles += new Vector3(0,sign * 90,0);
			}
		}

	}

}
