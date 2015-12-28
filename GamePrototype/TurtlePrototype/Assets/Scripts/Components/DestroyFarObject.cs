using UnityEngine;
using System.Collections;

public class DestroyFarObject : MonoBehaviour {

	public float DistanceZ = -100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (transform.position.z <= DistanceZ) {
			Destroy(gameObject);
		}
	}
}
