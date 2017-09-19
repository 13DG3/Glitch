using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;


public class PlayerMovementRF : MonoBehaviour {
    [SerializeField]
    private float moveSpeed =10;
    public float MoveSpeed
    {
        get
        {
            return moveSpeed;
        }
        set
        {
            moveSpeed = value;
        }
    }

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


	private bool facingRight = true;
	public bool FacingRight
	{
		get
		{
			return facingRight;
		}
	}

	private void MovePlayer()
	{
		rb.velocity = new Vector2(ReturnXInput() * moveSpeed, rb.velocity.y);
	}

	public float ReturnXInput()
	{
		return inputDev.LeftStickX;
	}

	public void SetUpPlayerMovement(InputDevice id, Rigidbody2D rigbod)
	{
		rb = rigbod;
		inputDev = id;
	}

	public void UpdatePlayerMovement()
	{
		MovePlayer();
		IsFacingRight();
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "MovingPlatform")
		{
			transform.parent = col.transform;
		}
	}

	void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag == "MovingPlatform")
		{
			transform.parent = null;
		}
	}

	public void IsFacingRight()
	{
		if (ReturnXInput() > 0f)
			facingRight = true;
		else if (ReturnXInput() < 0f)
			facingRight = false;
	}

	public bool IsWalking()
	{
		if (inputDev.LeftStickX > 0.1f || inputDev.LeftStickX < -0.1f)
			return true;
		else
			return false;
	}
}
