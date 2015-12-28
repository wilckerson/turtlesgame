using UnityEngine;
using System.Collections;

public interface IVelocity
{
	Vector3 GetVelocity ();
}

public class BasicMovement : MonoBehaviour
{

	public Vector3 Velocity;
	public GameObject Reference;

	public bool relative = false;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
	
		var vel = Velocity;
		if (Reference != null) {
			var comp = Reference.GetComponent<IVelocity> ();
			if (comp != null) {
				vel = comp.GetVelocity ();
			}
		}
		if (relative) {
			transform.Translate (vel * Time.deltaTime);
		} else {
			transform.position += vel * Time.deltaTime;
		}
	}
}
