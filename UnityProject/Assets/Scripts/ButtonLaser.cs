using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLaser : MonoBehaviour {
	public bool isGlitch = true;
	public SpriteRenderer buttonSprite;
	public Sprite[] buttons;
	public LaserTimer laser;
	//public Animator anim;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (isGlitch == true)
		{

			buttonSprite.sprite = buttons[0];
			laser.isLaserOn = true;
			laser.timeFactor = 0;
			//anim.SetBool ("isGlitch", true);
		}

		if (isGlitch == false)
		{

			buttonSprite.sprite = buttons[1];
			laser.isLaserOn = false;
			laser.timeFactor = 0;
			//anim.SetBool ("isGlitch", false);
		}

	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.gameObject.tag == "Glitch1" || col.gameObject.tag == "Glitch" )&& isGlitch )
		{
			isGlitch = false;

		}
	}
}
