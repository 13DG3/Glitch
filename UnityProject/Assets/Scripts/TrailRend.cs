using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRend : MonoBehaviour {
	public Color col1;
	public float curTime;
	public float maxTime = 0.1f;
	public SpriteRenderer alphaSprite;
	// Use this for initialization
	void Start () {
		curTime = 0;
		alphaSprite = GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		col1.a -= 10 * Time.deltaTime;
		alphaSprite.color = col1;
		curTime +=1 * Time.deltaTime;
		if (curTime >= maxTime) {
			Destroy (this.gameObject);
		}
	}
}
