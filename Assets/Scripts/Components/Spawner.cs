using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float IntervalSeconds = 1;
	public GameObject Prefab;

	float oldTime = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - oldTime > IntervalSeconds) {
			oldTime = Time.time;

			//Debug.Log("Interval");

			InstantiatePrefab();
		}
	}

	void InstantiatePrefab(){
		Instantiate(Prefab, transform.position, Quaternion.identity);
	}
}
