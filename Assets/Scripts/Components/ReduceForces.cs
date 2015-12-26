using UnityEngine;
using System.Collections;

public class ReduceForces : MonoBehaviour {

	Rigidbody rigidBody;
	public float reduceFactor = 0.5f;

	// Use this for initialization
	void Start () {
	
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (rigidBody != null) {

			rigidBody.velocity = rigidBody.velocity * reduceFactor;
			rigidBody.angularVelocity = rigidBody.angularVelocity * reduceFactor;

		}
	}
}
