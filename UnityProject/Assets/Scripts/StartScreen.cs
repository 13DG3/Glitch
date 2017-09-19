using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class StartScreen : MonoBehaviour {
	[SerializeField]
	private GameObject[] startScreenObjects;
	private InputDevice inputDev;
	[SerializeField]
	private float velocity = 2;
	private bool active;
	void Start () 
	{
		inputDev = InputManager.Devices [0];
	}
	
	// Update is called once per frame
	void Update () {
		if (inputDev.RightBumper.WasPressed) 
		{
			active = true;
			Destroy (startScreenObjects [0],4);
			Destroy (startScreenObjects [1],4);
			Destroy (startScreenObjects [2], 0.2f);
		}
		if (active && startScreenObjects[0]!=null) 
		{
			startScreenObjects [0].transform.position += Vector3.up * Time.deltaTime * velocity;
			startScreenObjects [1].transform.position -= Vector3.up * Time.deltaTime * velocity;

		}
	}
}
