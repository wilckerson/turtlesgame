using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameTags{
	public const string TagCoin = "TagCoin";
	public const string TagHurt = "TagHurt";
	public const string TagChild = "TagChild";

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
	public Text TxtChildren;
	public Text TxtLevel;
	public Text TxtLevelCenterScreen;

	public Vector3 MainVelocity;

	public AnimatedUV TunelAnimatedUV;
	public TouchPadFull TouchPadFullComponent;

	int coins;
	int dist;
	int lives;
	int hearts;
	float timer;
	int children;
	int levelChildren;
	int level;

	HeartCounter heartCounter;
	bool showLevelCenterScreen;
	float showLevelTimer = 0;

	public bool IsChangingLevel{
		get{
			return showLevelCenterScreen;
		}
	}

	// Use this for initialization
	void Start () {
		heartCounter = GetComponent<HeartCounter> ();

		//Application.targetFrameRate = 60;
		instance = this;
		//MainVelocity = new Vector3(0,0,-15);
		coins = 0;
		dist = 0;
		lives = 1;
		timer = 0;
		showLevelCenterScreen = false;

		level = 1;
		UpdateLevelCounter ();

		hearts = 1;
		UpdateHeartCounter ();

		children = 0;
		levelChildren = 3;
		UpdateChildrenCounter ();

	}
	
	// Update is called once per frame
	void Update () {
	
//		timer += Time.deltaTime;
//		if (timer >= 0.1) {
//			timer = 0;
//			dist++;
//			UpdateDistCounter ();
//		}

		if (children == levelChildren) {
			
			NextLevel ();
		}

		if (showLevelCenterScreen) {
			showLevelTimer += Time.deltaTime;

			if (showLevelTimer > 0.15f) {
				Time.timeScale = 1f;
				showLevelCenterScreen = false;
				TxtLevelCenterScreen.enabled = false;

				if(TouchPadFullComponent != null){
					TouchPadFullComponent.SetCanMove( true);
				}
			}
		}
	}

	void NextLevel(){

		MainVelocity.z -= 3;
		TunelAnimatedUV.uvAnimationRate.y += 0.1f;

		children = 0;
		levelChildren += 2;
		UpdateChildrenCounter ();

		level++;
		UpdateLevelCounter ();

		showLevelCenterScreen = true;
		showLevelTimer = 0;
		TxtLevelCenterScreen.enabled = true;

		Time.timeScale = 0.1f;

		if(TouchPadFullComponent != null){
			TouchPadFullComponent.SetCanMove( false);
		}
	}

	void UpdateCoinsCounter(){
		TxtCoins.text = coins.ToString ();
	}

	void UpdateDistCounter(){
		TxtDist.text = string.Format ("{0}m", dist);
	}

	void UpdateChildrenCounter(){
		TxtChildren.text = string.Format ("{0}/{1}", children,levelChildren);
	}

	void UpdateLevelCounter(){
		 TxtLevel.text = string.Format ("Level {0}", level);
		TxtLevelCenterScreen.text = TxtLevel.text;
		TxtLevelCenterScreen.enabled = false;
	}

	void UpdateHeartCounter(){
		if (heartCounter != null) {
			heartCounter.SetHearts (hearts);
		}
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
			MenuManager.Level = level;
			MenuManager.Coins=coins;
			SceneManager.LoadScene(GameScreens.MENU);
		}
	}

	public void GotChild(GameObject childObj){
		children++;
		UpdateChildrenCounter ();
		Destroy (childObj);
	}
}
