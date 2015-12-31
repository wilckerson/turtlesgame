using UnityEngine;
using System.Collections;

public class ChildrenSpawner : MonoBehaviour {

	public GameObject Prefab;
	public float MinInterval = 1;
	public float MaxInterval = 3;
	public float Dist = 3;
	float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > Random.Range(MinInterval,MaxInterval)) {
			time = 0;

			Vector3 randomPos = new Vector3 (
				Random.Range (-Dist, Dist),
				Random.Range (-Dist, Dist),
				0);

			Instantiate(
				Prefab,
				transform.position + randomPos,
				Quaternion.identity);

		}
	}
}
