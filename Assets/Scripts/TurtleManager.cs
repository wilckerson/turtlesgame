using UnityEngine;
using System.Collections;

public class TurtleManager : MonoBehaviour {

	public GameObject CoinCounterPrefab;

	void OnTriggerEnter(Collider other){
		Debug.Log("Trigger " + other.gameObject.tag);

		if (other.gameObject.tag == GameTags.TagCoin) {

			//Add the counter
			GameManager.Coins++;

			//Destroy the coin
			Destroy(other.gameObject);

			//instantiate coin counter sprite
			Instantiate(CoinCounterPrefab, transform.position, Quaternion.identity);

		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
