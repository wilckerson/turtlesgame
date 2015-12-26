using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public static int Coins = 0;
	public static int LevelCoins = 0;

	public Text txtCoins;

	// Use this for initialization
	void Start () {
	
		txtCoins.text = string.Format ("{0}/{1}", Coins, LevelCoins);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
