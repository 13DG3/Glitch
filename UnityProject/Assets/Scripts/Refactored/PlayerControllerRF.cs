using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerControllerRF : MonoBehaviour {
    private InputDevice joystick;
    public InputDevice Joystick
    {
        get
        {
            return joystick;
        }
    }
    private Rigidbody2D rb;
    private PlayerAnimationRF pa;
    private PlayerMovementRF pm;
    private PlayerPhysicsRF pp;
    private PlayerGlitchRF pg;
    private PlayerJumpRF pj;
    private PlayerRespawnRF pr;
    private PlayerFollowRF pf;
	private PlayerStartUp ps;
	[SerializeField]
	private bool isActive = true;
	public bool IsActive
	{
		set
		{ 
			isActive = value;
		}
		get
		{ 
			return isActive;
		}
	}
	[SerializeField]
	private bool isSelected = true;
	public bool IsSelected
	{
		set
		{
			isSelected = value;
		}
		get
		{
			return isSelected;
		}
	}

	void Awake () {
		SetUp();
		MakeSelected(isSelected);
		//rb.constraints = RigidbodyConstraints2D.FreezeAll;
	}
	void Update ()
	{
		PlayerControllerUpdate();
	}

	private void SetUp()
	{
		rb = GetComponent<Rigidbody2D>();
		joystick = InputManager.Devices[0];

		pm = GetComponent<PlayerMovementRF>();
		pm.SetUpPlayerMovement(joystick, rb);

		pp = GetComponent<PlayerPhysicsRF>();
		pp.SetUpPhysics(GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>(), rb);

		pg = GetComponent<PlayerGlitchRF>();
		pg.SetUpPlayerGlitch(joystick, rb);

		pj = GetComponent<PlayerJumpRF>();
		pj.SetUpPlayerJump( joystick, pp, pg, rb);

		pr = GetComponent<PlayerRespawnRF>();
		pr.SetUpPlayerRespawn();

		pf = GetComponent<PlayerFollowRF>();

		pa = GetComponent<PlayerAnimationRF>();
		pa.SetUpPlayerAnimation( pp, pm,pg, pr);

		ps = GetComponent<PlayerStartUp>();
		ps.SetUpPlayerStartUp(isActive, joystick);
	}
	private void PlayerControllerUpdate()
	{
		if (isActive)
		{
			if (isSelected)
			{
				pm.UpdatePlayerMovement();
				pg.UpdatePlayerGlitch(pp.Grounded);
				pj.UpdatePlayerJump(pg.WhatGlitchState());
			}
			else
			{
				MakeSelected(false);
			}
		}
		pp.UpdatePlayerPhysics();
		CheckPlayerActive();
		ps.UpdatePlayerStartUp();
		pf.UpdatePlayerFollow();
		pr.UpdatePlayerRespawn(pm.FacingRight);
		pa.UpdatePlayerAnimation(ps.WhatState(), pp.AreFeetGrounded(),pm.IsWalking(),pg.WhatGlitchState(), pr.ShouldRespawn, pm.FacingRight, IsSelected);
	}
	private void CheckPlayerActive()
	{
		if (ps.WhatState() == "On")
			isActive = true;
	}
	public void MakeSelected(bool activeState)
	{
		isSelected = activeState;
		if (activeState)
		{
			rb.constraints = RigidbodyConstraints2D.None;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		}
		else
		{
			if(pg.WhatGlitchState() != "glitching")
				rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			else
				rb.constraints = RigidbodyConstraints2D.FreezeAll;
		}
	}
    public void ResetPlayer(int glitchAmount)
    {
        pg.ResetGlitchStructure(glitchAmount);
    }
}
