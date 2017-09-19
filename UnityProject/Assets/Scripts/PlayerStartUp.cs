using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerStartUp : MonoBehaviour {
	[SerializeField]
	private bool player1;
	private enum StartUpStates {Off, StartingUp, On }
	private StartUpStates ss;
	private InputDevice inpuDev;

	private float timer;
	[SerializeField]
	private float period = 0.2f;

	public void UpdatePlayerStartUp ()
	{
		ShouldTurnOn();
	}
	public void SetUpPlayerStartUp(bool isActive, InputDevice iDev)
	{
		if (isActive)
			ss = StartUpStates.On;
		else
			ss = StartUpStates.Off;
		inpuDev = iDev;
	}
	private void ShouldTurnOn()
	{
		if (player1)
		{
			if (inpuDev.RightBumper.WasPressed)
			{
				ss = StartUpStates.StartingUp;
			}
		}
		if (ss == StartUpStates.StartingUp)
		{
			timer += Time.deltaTime;
			if (timer > period)
				ss = StartUpStates.On;
		}
	}
	public string WhatState()
	{
		if (ss == StartUpStates.StartingUp)
			return "StartingUp";
		else if (ss == StartUpStates.Off)
			return "Off";
		else
			return "On";
	}
	void OnTriggerEnter2D(Collider2D col)
	{
		if (!player1)
		{
			if (col.gameObject.tag == "Glitch1" && ss== StartUpStates.Off)
			{
				ss = StartUpStates.StartingUp;
			}
		}
	}
}
