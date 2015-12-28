using UnityEngine;
using System.Collections;

public class GameMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += GameManager.Instance.MainVelocity * Time.deltaTime;
	}
}
