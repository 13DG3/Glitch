using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonType2 : MonoBehaviour {
	public bool isGlitch = true;
	public SpriteRenderer buttonSprite;
	public Sprite[] buttons;
	public MovingPlatforms move;
	public MovingPlatStart startPlat;
	//public Animator anim;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isGlitch == true) {

			buttonSprite.sprite = buttons [0];
			move.enabled = false;
			startPlat.enabled = true;
			//anim.SetBool ("isGlitch", true);
		}

		if (isGlitch == false) {
			
			buttonSprite.sprite = buttons [1];
			move.enabled = true;
			startPlat.enabled = false;
			//anim.SetBool ("isGlitch", false);
		}
			
	}
	void OnTriggerEnter2D(Collider2D col){
		if ((col.gameObject.tag == "Glitch1" || col.gameObject.tag == "Glitch" )&& isGlitch )  {
			isGlitch = false;

		}


	}

}
