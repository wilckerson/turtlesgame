using UnityEngine;
using System.Collections;

public class GrassSpawner : MonoBehaviour {
	
	public GameObject Prefab;
	public float MinInterval = 1;
	public float MaxInterval = 3;
	public float DistX = 4;
	float time = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > Random.Range(MinInterval,MaxInterval)) {
			time = 0;


			float rnd = Random.Range (-1f, 1f);
			float posX = DistX * rnd;


			Vector3 randomPos = new Vector3 (posX,0,0);

			Instantiate(
				Prefab,
				transform.position + randomPos,
				Quaternion.identity);

		}
	}
}
