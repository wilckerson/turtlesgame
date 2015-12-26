using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	private static SceneManager sceneManager;
	public static SceneManager Instance {
		get{
			if(sceneManager == null){
				sceneManager = new SceneManager();
			}
			return sceneManager;
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void LoadGameScene(){
		Application.LoadLevel ("TurtleControl4");
	}

	public void LoadGameOverScene(){
		Application.LoadLevel ("GameOver");
	}
}
