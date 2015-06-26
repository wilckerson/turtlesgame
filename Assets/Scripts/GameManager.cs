using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour, IVelocity {

	public static int Coins = 0;

	public Vector3 MainVelocity;

	public Vector3 GetVelocity(){
		return MainVelocity;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
