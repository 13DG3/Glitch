using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class LevelEnd : MonoBehaviour {
	public string nextLevel;
	public bool isGlitch = false;
	public SpriteRenderer buttonSprite;
	public Sprite[] buttons;
	public int maxNo;
	public int curInt;
	public float maxTime;
	public float curTime;
	// Use this for initialization

	private float endLevelTimer;
	private float endLevelPeriod =0.4f;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (isGlitch == false) {
			buttonSprite.sprite = buttons [0];
			curTime = 0;

		}

		if (isGlitch == true) {
			buttonSprite.sprite = buttons [1];
			curTime += 1 * Time.deltaTime;

		}
		if (curTime >= maxTime)
			isGlitch = false;

		if (curInt >= maxNo)
			endLevel();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Glitch1" && !isGlitch) {
			isGlitch = true;
			Destroy (col.transform.parent.gameObject);
			curInt += 1;

		}


	}

	public void endLevel()
	{
		endLevelTimer += Time.deltaTime;
		if(endLevelTimer>endLevelPeriod)
			Application.LoadLevel(nextLevel);

	}
}
