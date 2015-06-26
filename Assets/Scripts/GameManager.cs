using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour, IVelocity {

	public GameObject CoinCounterPrefab;
	public Vector3 MainVelocity;
	
	int coins = 0;

	public Vector3 GetVelocity(){
		return MainVelocity;
	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void GotCoin(GameObject coinObj,Vector3 turtlePos){

		//Add the counter
		coins++;
		
		//Destroy the coin
		Destroy(coinObj);
		
		//instantiate coin counter sprite
		Instantiate(CoinCounterPrefab, turtlePos, Quaternion.identity);
		
		//Speed-Up
		MainVelocity -= new Vector3 (0, 0, 1f);
	}

}
