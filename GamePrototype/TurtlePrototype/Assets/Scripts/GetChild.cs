using UnityEngine;
using System.Collections;

public class GetChild : MonoBehaviour {

	void OnTriggerEnter(Collider other){

		Debug.Log("Trigger " + other.gameObject.tag);

		if (other.gameObject.tag == GameTags.TagChild) {
			GameManager.Instance.GotChild(other.gameObject);
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
