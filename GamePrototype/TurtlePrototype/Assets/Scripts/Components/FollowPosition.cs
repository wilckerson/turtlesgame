using UnityEngine;
using System.Collections;

public class FollowPosition : MonoBehaviour {

	public Transform Target;
	public float Damping = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.Lerp(transform.position, Target.position, Damping);
	}
}
