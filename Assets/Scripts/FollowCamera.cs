using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public GameObject target;
	public float damping = 1;
	Vector3 offset;
	
	void Start() {
		offset = target.transform.position - transform.position;
	}
	
	void LateUpdate() {
//		Vector3 currentAngle = transform.eulerAngles;
//		Vector3 desiredAngle = target.transform.eulerAngles;
//		float angleX = Mathf.Lerp(desiredAngle.x, currentAngle.x, Time.deltaTime * damping);
		//float angleY = Mathf.LerpAngle(currentAngle.y, desiredAngle.y, Time.deltaTime * damping);
//		float angleZ = Mathf.LerpAngle(currentAngle.z, desiredAngle.z, Time.deltaTime * damping);
//		

		Quaternion rotation = Quaternion.Euler(target.transform.eulerAngles.x,target.transform.eulerAngles.y,0);
//		transform.position = target.transform.position - (rotation * offset);

		var finalPosition = target.transform.position - (rotation * offset);

		transform.position = new Vector3(
			Mathf.Lerp(transform.position.x, finalPosition.x,Time.deltaTime * damping),
			Mathf.Lerp(transform.position.y, finalPosition.y,Time.deltaTime * damping),
			Mathf.Lerp(transform.position.z, finalPosition.z,Time.deltaTime * damping));

		float angleZ = Mathf.LerpAngle(transform.localEulerAngles.z,target.transform.localEulerAngles.z,Time.deltaTime * damping);

		transform.LookAt(target.transform);
		transform.localEulerAngles = new Vector3(
			transform.localEulerAngles.x,
			transform.localEulerAngles.y,
			angleZ);
	}
}
