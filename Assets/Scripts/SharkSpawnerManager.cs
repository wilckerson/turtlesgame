using UnityEngine;
using System.Collections;

public class SharkSpawnerManager : MonoBehaviour, ISpawnerListener {
	
	public GameObject GameManager;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnSpawn(GameObject spawnedObject){
		
		var basicMovement = spawnedObject.GetComponent<BasicMovement> ();
		
		if(basicMovement != null){
			basicMovement.Reference = GameManager;
		}
		
	}
}
