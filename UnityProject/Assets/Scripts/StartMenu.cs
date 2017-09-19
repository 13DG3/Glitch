using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class StartMenu : MonoBehaviour {
	public string level;
	private InputDevice joystick;
	// Use this for initialization
	void Start () {
		joystick = InputManager.Devices[0];
		Time.timeScale = 1f;
	}
	
	// Update is called once per frame
	void Update () {
		Time.timeScale = 1f;
		if (joystick.RightBumper) {
			Application.LoadLevel (level);
		}
	}
}
