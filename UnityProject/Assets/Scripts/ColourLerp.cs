using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourLerp : MonoBehaviour {
	SpriteRenderer spriteRenderer;
	public Color colour1 = new Vector4(1,128,146,1);
	public Color colour2 = new Vector4(0,0,0,1);
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		spriteRenderer.color = Color.Lerp(colour1, colour2, Mathf.PingPong(Time.time /40f, 1));

	}
}
