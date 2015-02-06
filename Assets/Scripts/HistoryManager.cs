using UnityEngine;
using System.Collections;

public class HistoryManager : MonoBehaviour {

	public SlideShow slideShow;
	public RectTransform Panel;
	bool panelScaleDown = false;

	// Use this for initialization
	void Start () {
	
		slideShow.OnSlideShowStop += HandleOnSlideShowStop;

		//Verify is history was played before
		//Else, play it
		PlayHistory();
	}

	void HandleOnSlideShowStop ()
	{
		panelScaleDown = true;
		Debug.Log("Stoped"); 
	}

	public void PlayHistory(){
		Debug.Log("PlayHistory");
		Panel.gameObject.SetActive(true);
		slideShow.Play();

	}
	
	// Update is called once per frame
	void Update () {
		if(panelScaleDown)
		{
			Panel.localScale -= new Vector3(0.5f*Time.deltaTime,0.5f*Time.deltaTime);
			//Debug.Log(Panel.localScale);

			if(Panel.localScale.x < 0 || Panel.localScale.x < 0.01)
			{
				Panel.localScale = Vector3.one;
				Panel.gameObject.SetActive(false);
				panelScaleDown = false;
			}
		}
	}
}
