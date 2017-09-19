using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerJumpRF : MonoBehaviour {
    private PlayerPhysicsRF pp;
    private PlayerGlitchRF pg;
    private Rigidbody2D rb;
    public Rigidbody2D Rb
    {
        get
        {
            return rb;
        }
        set
        {
            Rb = value;
        }
    }
    private InputDevice inputDev;
    public InputDevice InputDev
    {
        get
        {
            return inputDev;
        }
        set
        {
            inputDev = value;
        }
    }

    private float jumpTimer = 0.25f;
    [SerializeField]
    private float jumpTime = 0.25f;
    [SerializeField]
    private float jumpForce = 23;

    private bool canGlitchJump;
    private bool glitchJumping;
    private bool canJump;
    private bool jumping;

    private float glitchJumpTimer;
    [SerializeField]
    private float glitchJumpTime = 0.25f;

	public void SetUpPlayerJump(InputDevice iDev, PlayerPhysicsRF playerPhys, PlayerGlitchRF pGlitch, Rigidbody2D rigb)
	{
		inputDev = iDev;
		rb = rigb;
		pp = playerPhys;
		pg = pGlitch;
	}

	public void UpdatePlayerJump(string glitchState)
	{
		if (glitchState == "canGlitch")
		{
            GlitchJump();
			Jump();
        }
		else if (glitchState == "glitching")
			ShouldGlitchJump();
		else
		{
			GlitchJump();
			Jump();
		}
    }

	private void GlitchJump()
	{
		if (glitchJumping)
		{
            glitchJumpTimer += Time.deltaTime;
			if (glitchJumpTimer < glitchJumpTime)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			}
			else
			{
				glitchJumping = false;
				glitchJumpTimer = 0;
			}
		}
	}

	private void ShouldGlitchJump()
	{
		if (inputDev.Action1.WasPressed)
		{
			glitchJumping = true;
			pg.SetGlitchState();
		}
	}

	private void Jump()
	{
		if (pp.Grounded || pp.HeadGrounded)
		{
			canJump = true;
		}
        if (inputDev.Action1.WasPressed &&canJump)
        {
            jumping = true;
        }
        if (jumping)
        {
            jumpTimer += Time.deltaTime;
            if (jumpTimer < jumpTime)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                canJump = false;
            }
            else
            {
                jumping = false;
                jumpTimer = 0;
            }
        }
        /*if ((inputDev.Action1.WasPressed) && (canJump))
		{
			jumpTimer = 0;
		}
		if (inputDev.Action1.WasReleased)
			jumpTimer = jumpTime;
		if (inputDev.Action1)
		{
			canJump = false;
			jumpTimer += Time.deltaTime;
			if (jumpTimer < jumpTime)
			{
				jumpTimer += Time.deltaTime;
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			}
		}*/
    }


}
