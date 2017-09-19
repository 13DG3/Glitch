using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CameraMovement : MonoBehaviour {
	public Transform target;
	public Transform target2;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	public float xOffset = 0.5f;
	public float yOffset = 0.5f;
	private InputDevice joystick;
	public int playerInt = 0;
	public float lookSpeed = 1;
	public bool isSwitch = true; 
	public PlayerController[] players;
	public SwitchController[] switchCon;
	public GameObject[] glitchCam;
	private bool firstSwitch = false;
	// Use this for initialization
	public bool level1;
	// Use this for initialization
	void Start () {
		joystick = InputManager.Devices[playerInt];
		isSwitch = true;


	}

	// Update is called once per frame
	void Update () {

		/*if (target) {
			Vector3 point = Camera.main.WorldToViewportPoint (target.position);
			Vector3 delta = target.position - Camera.main.ViewportToWorldPoint (new Vector3 (xOffset, yOffset, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
		}*/
		if (joystick.Action2.WasPressed) {
			isSwitch = !isSwitch;
			firstSwitch = true;

		}
		if (level1)
		{
			Vector3 point = Camera.main.WorldToViewportPoint(target.position);
			Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(xOffset, yOffset, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination = transform.position + delta;
			players[0].enabled = true;
			switchCon[0].enabled = false;
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		else if (isSwitch == true)
		{
			if (players [0] != null) {
				Vector3 point = Camera.main.WorldToViewportPoint (target.position);
				Vector3 delta = target.position - Camera.main.ViewportToWorldPoint (new Vector3 (xOffset, yOffset, point.z)); //(new Vector3(0.5, 0.5, point.z));
				Vector3 destination = transform.position + delta;
				players [0].enabled = true;
				switchCon [0].enabled = false;
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
				glitchCam [0].SetActive (true);
			} else {
				glitchCam [0].SetActive (false);
				isSwitch = false;
			}
			if (players[1] != null)
			{
				players[1].enabled = false;
				glitchCam [1].SetActive (false);
				switchCon[1].enabled = true;
			}

		}
		else
		{
			if (players [1] != null) {
				Vector3 point = Camera.main.WorldToViewportPoint (target2.position);
				Vector3 delta = target2.position - Camera.main.ViewportToWorldPoint (new Vector3 (xOffset, yOffset, point.z)); //(new Vector3(0.5, 0.5, point.z));
				Vector3 destination = transform.position + delta;
				players [1].enabled = true;
				switchCon [1].enabled = false;
				transform.position = Vector3.SmoothDamp (transform.position, destination, ref velocity, dampTime);
				glitchCam [1].SetActive (true);

			} else {
				isSwitch = true;
				glitchCam [1].SetActive (false);
			}
			if (players[0] != null)
			{
				players[0].enabled = false;
				switchCon[0].enabled = true;
				glitchCam[0].SetActive(false);
			}

		}





	}

	/*void FixedUpdate (){
		if (joystick.LeftStickX) {
			float x = joystick.LeftStickX * lookSpeed;
			if (x > 0)
				xOffset = 0.44f;

			if (x < 0)
				xOffset = 0.56f;
		} else {
			xOffset = 0.5f;
		}
	}*/
}
