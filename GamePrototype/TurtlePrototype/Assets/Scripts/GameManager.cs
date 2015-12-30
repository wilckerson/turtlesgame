using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameTags{
	public const string TagCoin = "TagCoin";
	public const string TagHurt = "TagHurt";

}

public class GameManager : MonoBehaviour {

	static GameManager instance;
	public static GameManager Instance {get{ 
			if(instance == null){
				instance = new GameManager();
			}
			return instance;
		}}

	public Text TxtCoins;
	public Text TxtDist;

	public Vector3 MainVelocity;
	int coins;
	int dist;
	int lives;

	float timer;

	// Use this for initialization
	void Start () {
		Application.targetFrameRate = 60;
		instance = this;
		//MainVelocity = new Vector3(0,0,-15);
		coins = 0;
		dist = 0;
		lives = 1;
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		timer += Time.deltaTime;
		if (timer >= 0.1) {
			timer = 0;
			dist++;
			UpdateDistCounter ();
		}
	}

	void UpdateCoinsCounter(){
		TxtCoins.text = coins.ToString ();
	}

	void UpdateDistCounter(){
		TxtDist.text = string.Format ("{0}m", dist);
	}

	public  void GotCoin(GameObject coinObj){
		coins++;
		UpdateCoinsCounter ();
		Destroy (coinObj);
	}

	public  void GotHurt(){
		lives--;
		if (lives == 0) {
			//Game Over
			MenuManager.Dist = dist;
			MenuManager.Coins=coins;
			SceneManager.LoadScene(GameScreens.MENU);
		}
	}
}
