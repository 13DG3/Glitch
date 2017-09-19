using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {
	public bool isGlitch = true;
	public GameObject door;
	public SpriteRenderer buttonSprite;
	public Sprite[] buttons;
	//public Animator anim;
	// Use this for initialization
	void Start () {
		//isGlitch = true;
		//door.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		if (isGlitch == true) {
			door.SetActive (true);
			buttonSprite.sprite = buttons [0];
			//anim.SetBool ("isGlitch", true);
		}
		if (isGlitch == false) {
			door.SetActive (false);
			buttonSprite.sprite = buttons [1];
			//anim.SetBool ("isGlitch", false);
		}
			
	}

	void OnTriggerEnter2D(Collider2D col){
		if ((col.gameObject.tag == "Glitch1" || col.gameObject.tag == "Glitch" )&& isGlitch ) {
			isGlitch = false;
			door.SetActive (false);
		}


	}
}
