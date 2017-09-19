using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTimer : MonoBehaviour {
	public SpriteRenderer startLaser;
	public SpriteRenderer endLaser;
	public Sprite[] start;
	public Sprite[] end;
	public bool isLaserOn;
	public float curTime = 0;
	public float maxTime = 1f;
	public GameObject laser;
	public GameObject laser2;
	public float midTime = 2f;
	public float timeFactor =1;
	// Use this for initialization
	void Start () {
		isLaserOn = true;
		curTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		curTime += timeFactor * Time.deltaTime;

		if (curTime >= maxTime) {
			isLaserOn =! isLaserOn;
			curTime = 0;
		}

		if (curTime >= midTime) {
			laser2.SetActive (true);
		} else {
			laser2.SetActive (false);
		}
	

		if (isLaserOn) {
			laser.SetActive (true);
			startLaser.sprite = start [0];
			endLaser.sprite = end [0];
		}

		if (!isLaserOn) {
			laser.SetActive (false);
			startLaser.sprite = start [1];
			endLaser.sprite = end [1];
		}
	}


}
