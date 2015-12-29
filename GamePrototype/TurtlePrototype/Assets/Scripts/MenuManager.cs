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

	public static int Coins;
	public static int Dist;

	// Use this for initialization
	void Start () {
		
		TxtDist.text = string.Format ("{0}m",Dist);
		TxtCoins.text = Coins.ToString ();
		TxtTotal.text = string.Format ("TOTAL: {0}",Coins);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClickPlay(){
		SceneManager.LoadScene("Game");
	}
}
