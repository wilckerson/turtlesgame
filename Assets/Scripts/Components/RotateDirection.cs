using UnityEngine;
using System.Collections;

public class RotateDirection : MonoBehaviour {

	public GameObject Reference;
	public float RotationVelocity = 5;

	HalfScreenDirection directionComponent;

	// Use this for initialization
	void Start () {
	
		if (Reference == null) {
			Reference = this.gameObject;
		}

		directionComponent = Reference.GetComponent<HalfScreenDirection> ();
		if (directionComponent == null) {
			throw new UnityException (string.Format("The gameObject {0} must have a Direction component",Reference.name));
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (directionComponent != null) {
			Reference.transform.Rotate (
				0,
				directionComponent.GetDirection().x * RotationVelocity * Time.deltaTime,
				0);
		}
		

	}
}
