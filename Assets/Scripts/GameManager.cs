using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour, IVelocity {

	public GameObject CoinCounterPrefab;
	public Vector3 MainVelocity;
	public Text TxtLevel;
	public Text TxtCoins;

	int coins = 0;
	int nextLevelCoins = 5;
	int level = 1;

	public Vector3 GetVelocity(){
		return MainVelocity;
	}

	// Use this for initialization
	void Start () {
		UpdateTxtLevel ();
		UpdateTxtCoins ();
	}
	
	// Update is called once per frame
	void Update () {
	
		//Simple next level
		if (coins >= nextLevelCoins) {
			level++;
			UpdateTxtLevel();

			coins = 0;
			nextLevelCoins = 3 + (level * 2);
			UpdateTxtCoins ();

			//Speed-Up
			MainVelocity -= new Vector3 (0, 0, 20f);
		}
	}

	public void GotCoin(GameObject coinObj,Vector3 turtlePos){

		//Add the counter
		coins++;
		UpdateTxtCoins ();
		
		//Destroy the coin
		Destroy(coinObj);
		
		//instantiate coin counter sprite
		Instantiate(CoinCounterPrefab, turtlePos, Quaternion.identity);

	}

	void UpdateTxtCoins(){

		TxtCoins.text = string.Format ("{0}/{1}", coins, nextLevelCoins);
	}

	void UpdateTxtLevel(){
		TxtLevel.text = string.Format ("Level {0}", level);
	}
}
