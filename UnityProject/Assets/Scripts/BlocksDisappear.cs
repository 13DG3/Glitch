using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocksDisappear : MonoBehaviour {
	public float curTime = 0;
	public float maxTime = 3;
	public GameObject block;
	public bool isGlitch;
	public SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
		block.SetActive (true);
		isGlitch = false;
	}
	
	// Update is called once per frame
	void Update () {
		curTime += 1 * Time.deltaTime;
		if (curTime >= maxTime &&!isGlitch) {
			block.SetActive (false);
			curTime = 0;
			isGlitch = true;
		}

		if (curTime >= maxTime && isGlitch) {
			block.SetActive (true);
			curTime = 0;
			isGlitch = false;
		}
	}
}
