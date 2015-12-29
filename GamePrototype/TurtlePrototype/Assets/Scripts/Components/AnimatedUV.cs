using UnityEngine;
using System.Collections;

public class AnimatedUV : MonoBehaviour {

	public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );

	Vector2 uvOffset = Vector2.zero;
	Renderer rend;

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//void LateUpdate() 
		if( rend != null )
		{
			uvOffset += ( uvAnimationRate * Time.deltaTime );

			var material = rend.materials [materialIndex];
				
			material.mainTextureOffset = uvOffset;
		}

	}
}
