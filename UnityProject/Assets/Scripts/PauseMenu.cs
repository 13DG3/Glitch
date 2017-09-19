using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PauseMenu : MonoBehaviour {
	
	public string mainMenu;
	public bool isPaused;
	public GameObject pauseMenuCanvas;
	private InputDevice joystick;
	// Use this for initialization
	void Start () {
		joystick = InputManager.Devices[0];
	}
	
	// Update is called once per frame
	void Update () {
		if (isPaused) {

			pauseMenuCanvas.SetActive (true);
			Time.timeScale = 0f;
		} 

		else {
			pauseMenuCanvas.SetActive (false);
			Time.timeScale = 1f;
		}

		if (joystick.MenuWasPressed) {

			isPaused =! isPaused;
		}
	}

	public void Quit (){

		Application.LoadLevel (mainMenu);	
	}

	public void Restart (){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void Resume (){

		isPaused = false;
	}
}
