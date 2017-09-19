using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovingTerrain : MonoBehaviour {
    public bool isGlitch = true;
    public SpriteRenderer buttonSprite;
    public Sprite[] buttons;
    public MovingTerrain movTerrain;
	private float activeTimer;
	public float activePeriod = 5;
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
			//anim.SetBool ("isGlitch", true);
		}

		if (isGlitch == false)
		{

			buttonSprite.sprite = buttons[1];
			movTerrain.shouldMove = true;
			activeTimer += Time.deltaTime;
			if (activeTimer > activePeriod)
			{
				activeTimer = 0;
				isGlitch = true;
				movTerrain.shouldMove = false;
			}
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
