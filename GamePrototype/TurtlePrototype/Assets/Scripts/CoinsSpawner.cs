using UnityEngine;
using System.Collections;

public class CoinsSpawner : MonoBehaviour {

	public GameObject CoinPrefab;
	public float MinInterval = 1;
	public float MaxInterval = 3;
	public float DistX = 2;
	float time = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if (time > Random.Range(MinInterval,MaxInterval)) {
			time = 0;

			float posX = 0;
			float rnd = Random.Range (0, 1f);
			//Debug.Log (rnd);
			if (rnd < 0.33f) {
				posX = -DistX;
			}
			else if(rnd > 0.66f){
				posX = DistX;
			}

			Vector3 randomPos = new Vector3 (posX,0,0);

			Instantiate(
				CoinPrefab,
				transform.position + randomPos,
				Quaternion.identity);

		}
	}
}
