using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;
//using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public static int collectedOrbs = 0;
	private InputDevice joystick;
	public PlayerController p2con;
	public PlayerController p1con;
	public Rigidbody2D rb;
	public Rigidbody2D rb2;
	public Camera camP2;
	public bool isSwitch = true; 
	// Use this for initialization
	void Start () {
		collectedOrbs = 0;
		p1con.enabled = true;
		p2con.enabled = false;
		//camP1.enabled = true;
		//camP2.enabled = false;
		joystick = InputManager.Devices[0];

	}
	
	// Update is called once per frame
	void Update () {
		if (joystick.Action2.WasPressed) {
			isSwitch = !isSwitch;

			if (isSwitch == true) {

				p1con.enabled = true;
				p2con.enabled = false;
				//rb2.constraints = RigidbodyConstraints2D.FreezePositionX;
			
			
				//camP1.enabled = true;
				//camP2.enabled = false;


			}

			if (isSwitch == false) {

				p2con.enabled = true;
				p1con.enabled = false;
				//rb.constraints = RigidbodyConstraints2D.FreezePositionX;

			

			}


		}
			



		if (Input.GetKey(KeyCode.Escape))
			Application.Quit ();
	}



}
