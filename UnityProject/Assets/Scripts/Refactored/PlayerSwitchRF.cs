using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerSwitchRF : MonoBehaviour {
    [SerializeField]
    private PlayerControllerRF player1;
    [SerializeField]
    private PlayerControllerRF player2;
    private PlayerControllerRF activePlayer;
    public PlayerControllerRF ActivePlayer
    {
        get
        {
            return activePlayer;
        }
    }
    private InputDevice inputDev;
	private bool canStart = true;
	private float timer;
	[SerializeField]
	private float period = 0.1f;
	// Use this for initialization
	void Start ()
	{
		activePlayer = player1;
		inputDev = player1.Joystick;
	}

	// Update is called once per frame
	void Update ()
	{
		LevelSetup();
		ChangePlayer();
	}

	private void LevelSetup()
	{
		if (canStart)
		{
			if (player1.IsActive) {
				//timer += Time.deltaTime;
				//if (timer > period) {
				player1.IsSelected =true;
				if (player2 != null) {
					player2.IsSelected = false;
					//}
					canStart = false;
				}
			}
		}
	}

	private void ChangePlayer()
	{
		if (!canStart)
		{
			if (inputDev.Action2.WasPressed)
			{
				if (player2.IsActive)
				{
					if (activePlayer == player1 && player2 != null)
					{
						activePlayer = player2;
						player1.MakeSelected(false);
						player2.MakeSelected(true);
					}
					else
					{
						activePlayer = player1;
						player1.MakeSelected(true);
						player2.MakeSelected(false);
					}
				}
			}
		}
	}
}
