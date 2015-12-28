using UnityEngine;
using System.Collections;

public class GetHurt : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		Debug.Log("Trigger " + other.gameObject.tag);

		if (other.gameObject.tag == GameTags.TagHurt) {
			GameManager.Instance.GotHurt();
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
