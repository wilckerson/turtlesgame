using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeartCounter : MonoBehaviour {

//	private static HeartCounter instance;
//	public static HeartCounter Instance{
//		get{
//			if (instance == null) {
//				instance = new HeartCounter ();
//			}
//
//			return instance;
//		}
//	}

	public Image[] imgHearts;

	// Use this for initialization
	void Start () {
		//instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetHearts(int count){
		
		for (int i = 0; i < imgHearts.Length; i++) {
			
			imgHearts[i].enabled = (i <= count-1);
		}
	}
}
