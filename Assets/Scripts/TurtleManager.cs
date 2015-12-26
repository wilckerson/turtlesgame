using UnityEngine;
using System.Collections;

public class TurtleManager : MonoBehaviour {

	public GameManager GameManager;


	void OnTriggerEnter(Collider other){
		Debug.Log("Trigger " + other.gameObject.tag);

		if (other.gameObject.tag == GameTags.TagCoin) {
			Destroy (other.gameObject);
			GameManager.GotCoin(other.gameObject,transform.position);
		}
		else if (other.gameObject.tag == GameTags.Spike) {
			//Application.LoadLevel (Application.loadedLevelName);
			GameManager.GotSpike();
		}

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
