using UnityEngine;
using System.Collections;

public class TargetMovement : MonoBehaviour {

	public float Dist = 2;

	ScreenPadDirection directionComponent;

	// Use this for initialization
	void Start () {
	
		directionComponent = GetComponent<ScreenPadDirection> ();
		if (directionComponent == null) {
			throw new UnityException (string.Format("The object {0} must have a Direction component",this.name));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
		if (directionComponent != null) {

			transform.position = new Vector3 (
				directionComponent.GetDirection().x * Dist,
				transform.position.y,
				transform.position.z);

		}
	}
}
