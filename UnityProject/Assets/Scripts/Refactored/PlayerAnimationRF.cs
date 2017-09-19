using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationRF : MonoBehaviour {
    private Animator anim;
    private SpriteRenderer sr;

	private PlayerRespawnRF pr;
    private PlayerPhysicsRF pp;
    private PlayerMovementRF pm;
    private PlayerGlitchRF pg;
	private PlayerControllerRF pc;
    private bool facingRight = true;

	public bool FacingRight
	{
		get
		{
			return facingRight;
		}
	}
    // Use this for initialization
	
	// Update is called once per frame
	public void SetUpPlayerAnimation(PlayerPhysicsRF playerPhys, PlayerMovementRF playerMove, PlayerGlitchRF playerGlitch, PlayerRespawnRF playerRes)
	{
		pc = GetComponent<PlayerControllerRF> ();
		sr = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
		pp = playerPhys;
		pm = playerMove;
		pg = playerGlitch;
		pr = playerRes;
	}
	public void UpdatePlayerAnimation(string state, bool grounded, bool isWalking, string whichGlitchState, bool respawn, bool facingRight, bool isSelected)
	{
		if (state == "Off")
			SetOffAnim(true);
		else if (state == "StartingUp")
			SetOffAnim(false);
		else
		{
			if (grounded)
			{
				if (isWalking && isSelected)
					SetWalkingAnim(true);
				else
					SetWalkingAnim(false);
				SetGroundedAnim(true);
			}
			else
				SetGroundedAnim(false);
			if (whichGlitchState == "glitching")
				SetGlitchingAnim(true);
			else
				SetGlitchingAnim(false);
			if (respawn)
				SetDeadAnim(true);
			else
				SetDeadAnim(false);
			if (facingRight)
				sr.flipX = false;
			else
				sr.flipX = true;
		}
	}
	private void SetGroundedAnim(bool state)
	{
		anim.SetBool("isGrounded", state);
	}
	private void SetGlitchingAnim(bool state)
	{
		anim.SetBool("isGlitching", state);
	}
	private void SetWalkingAnim(bool state)
	{
		anim.SetBool("isWalk", state);
	}
	private void SetDeadAnim(bool state)
	{
		anim.SetBool ("isDead", state);
	}
	private void SetOffAnim(bool state)
	{
		anim.SetBool ("isOff", state);
	}
}
