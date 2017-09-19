using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour {
	public bool isGlitch = true;
	public Rigidbody2D rb;
	public float curTime = 0;
	public float maxTime = 1;
	public SpriteRenderer boxSprite;
	public Sprite[] boxes;
	//public Animator anim;
	// Use this for initialization
	void Start () {
		isGlitch = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGlitch == true) {
			//anim.SetBool ("isGlitch", true);
			boxSprite.sprite = boxes[0];
			rb.constraints = RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;
			//curTime = 0;
		}
		if (isGlitch == false) {
			//anim.SetBool ("isGlitch", false);
			boxSprite.sprite = boxes[1];
			rb.constraints = RigidbodyConstraints2D.None;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			//curTime += 1 * Time.deltaTime;
		}

		if (curTime >= maxTime) {
			//isGlitch = true;
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Glitch1" || col.gameObject.tag == "Glitch" /*&& isGlitch*/) 
		{
			isGlitch = false;
			//curTime = 0;
		}


	}
}
