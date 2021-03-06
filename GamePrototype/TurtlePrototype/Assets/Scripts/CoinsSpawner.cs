﻿using UnityEngine;
using System.Collections;

public class CoinsSpawner : MonoBehaviour {

	public GameObject CoinPrefab;
	public int pulseMax = 10;

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

			for (int i = 0; i < Random.Range (1, pulseMax); i++) {
				randomPos.z = 4 * i;

				Instantiate (
					CoinPrefab,
					transform.position + randomPos,
					Quaternion.identity);
			}

		}
	}
}
