using UnityEngine;
using System.Collections;

public class RockSpawner : MonoBehaviour {

	public GameObject Rock1x1Prefab;
	public GameObject Rock2x1Prefab;
	public GameObject Rock1_1x1Prefab;

	public float Rock1x1Probality;
	public float Rock2x1Probality;
	public float Rock1_1x1Probality;


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



			//Random rock
			float rndRock = Random.Range (0, 1f);
			Debug.Log (string.Format("RndRock: {0}",  rndRock));

			if (rndRock <= Rock1x1Probality) {

				//Random position
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
					Rock1x1Prefab,
					transform.position + randomPos,
					Quaternion.identity);

			}
			else if(rndRock > Rock1x1Probality && rndRock < Rock2x1Probality + Rock1x1Probality){
				
				//Random position
				float posX = DistX/2;
				float rnd = Random.Range (0, 1f);
				//Debug.Log (rnd);
				if (rnd <= 0.5f) {
					posX = -DistX/2;
				}

				Vector3 randomPos = new Vector3 (posX,0,0);

				Instantiate(
					Rock2x1Prefab,
					transform.position + randomPos,
					Quaternion.identity);
			}
			else if(rndRock > Rock2x1Probality + Rock1x1Probality && rndRock < Rock1_1x1Probality + Rock2x1Probality + Rock1x1Probality ){

				Instantiate(
					Rock1_1x1Prefab,
					transform.position,
					Quaternion.identity);
			}

		}
	}
}
