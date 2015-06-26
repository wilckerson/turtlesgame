using UnityEngine;
using System.Collections;

public class CoinCounterMovement : MonoBehaviour {

	public float Velocity = 10;
	public float Duration = 2;

	float time;
	TextMesh textMesh;

	// Use this for initialization
	void Start () {
		time = Duration;
		textMesh = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.position += new Vector3 (0, Velocity * Time.deltaTime, 0);

		var color = textMesh.color;
		color.a = time/Duration;
		textMesh.color = color;

		time -= Time.deltaTime;

		if (time <= 0) {
			Destroy(gameObject);
		}

	}
}
