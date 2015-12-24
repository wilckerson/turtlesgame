using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {

	public Text txt;
	public int timeSec = 30;

	float time = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		time += Time.deltaTime;

		Debug.Log (time);

		if (time >= 1) {
			time = 0;
			timeSec--;
		}

		if (timeSec == 0) {
			Application.LoadLevel (Application.loadedLevelName);
		}

		txt.text = string.Format ("Tempo: {0}s", timeSec);

	}
}
