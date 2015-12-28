using UnityEngine;
using System.Collections;

public class GetCoin : MonoBehaviour {


	void OnTriggerEnter(Collider other){

		Debug.Log("Trigger " + other.gameObject.tag);

		if (other.gameObject.tag == GameTags.TagCoin) {
			GameManager.Instance.GotCoin(other.gameObject);
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
