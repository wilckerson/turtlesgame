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


	public Text TxtDist;
	public Text TxtCoins;
	public Text TxtTotal;
	public Text TxtRecord;

	public static int Dist;
	public static int Coins;

	static int TotalCoins;
	static int DistRecord;

	// Use this for initialization
	void Start () {
		TotalCoins += Coins;

		TxtDist.text = string.Format ("{0}m",Dist);
		TxtCoins.text = Coins.ToString ();
		TxtTotal.text = string.Format ("TOTAL: {0}",TotalCoins);

		if (DistRecord == 0 || Dist > DistRecord) {
			TxtRecord.text = "New Record! \\o/";
			DistRecord = Dist;
		} else {
			TxtRecord.text = string.Format ("Record: {0}m",DistRecord);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickPlay(){
		SceneManager.LoadScene(GameScreens.GAME_FULL);
	}
}
