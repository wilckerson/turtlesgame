using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	static MenuManager instance;
	public static MenuManager Instance {get{ 
			if(instance == null){
				instance = new MenuManager();
			}
			return instance; }}


	public Text TxtLevel;
	public Text TxtCoins;
	public Text TxtTotal;
	public Text TxtRecord;

	public static int Level;
	public static int Coins;

	static int TotalCoins;
	static int LevelRecord;

	// Use this for initialization
	void Start () {
		TotalCoins += Coins;

		TxtLevel.text = string.Format ("Level {0}",Level);
		TxtCoins.text = Coins.ToString ();
		TxtTotal.text = string.Format ("TOTAL: {0}",TotalCoins);

		if (LevelRecord == 0 || Level > LevelRecord) {
			TxtRecord.text = "New Record! \\o/";
			LevelRecord = Level;
		} else {
			TxtRecord.text = string.Format ("Record: Level {0}",LevelRecord);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickPlay(){
		SceneManager.LoadScene(GameScreens.TUNEL);
	}
}
