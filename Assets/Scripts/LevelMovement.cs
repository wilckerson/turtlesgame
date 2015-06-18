using UnityEngine;
using System.Collections;

public class LevelMovement : MonoBehaviour {

	public float Velocity = 0.3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += new Vector3 (0, 0, -Velocity * Time.deltaTime);
	}
}
