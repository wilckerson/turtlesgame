﻿using UnityEngine;
using System.Collections;

public class FollowTarget: MonoBehaviour {
	public Transform target;
	public float damping = 1;
	public bool LockRotation = false;
	public bool ApplyOffset = true;

	Vector3 offset;
	
	void Start() {
		if (ApplyOffset) {
			offset = target.transform.position - transform.position;
		}
	}
	
	void LateUpdate() {
//		Vector3 currentAngle = transform.eulerAngles;
//		Vector3 desiredAngle = target.transform.eulerAngles;
//		float angleX = Mathf.Lerp(desiredAngle.x, currentAngle.x, Time.deltaTime * damping);
		//float angleY = Mathf.LerpAngle(currentAngle.y, desiredAngle.y, Time.deltaTime * damping);
//		float angleZ = Mathf.LerpAngle(currentAngle.z, desiredAngle.z, Time.deltaTime * damping);
//		

		Quaternion rotation = Quaternion.Euler(
			target.eulerAngles.x,
			target.eulerAngles.y,
			0);
//		transform.position = target.transform.position - (rotation * offset);

		var finalPosition = target.transform.position - (rotation * offset);

		transform.position = new Vector3(
			Mathf.Lerp(transform.position.x, finalPosition.x,Time.deltaTime * damping),
			Mathf.Lerp(transform.position.y, finalPosition.y,Time.deltaTime * damping),
			Mathf.Lerp(transform.position.z, finalPosition.z,Time.deltaTime * damping));

		float angleZ = Mathf.LerpAngle(transform.localEulerAngles.z,target.localEulerAngles.z,Time.deltaTime * damping);

		if (!LockRotation) {
			
			transform.LookAt (target);
			transform.localEulerAngles = new Vector3(
				transform.localEulerAngles.x,
				transform.localEulerAngles.y,
				angleZ);
				}

	}
}
