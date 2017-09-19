using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerGlitchRF : MonoBehaviour
{
    private float glitchTimer;

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
    private enum GlitchState { canGlitch, glitching, cantGlitch };
    private GlitchState playerGlitchState = GlitchState.canGlitch;

    [SerializeField]
    public GameObject glitchIcon;
    [SerializeField]
    public GameObject glitchCol;
    [SerializeField]
    private int maxGlitches;
    [SerializeField]
    private int currentGlitches;
    public int MaxGlitches
    {
        set
        {
            maxGlitches = value;
        }
        get
        {
            return maxGlitches;
        }
    }
    public int CurrentGlitches
    {
        get
        {
            return currentGlitches;
        }
        set
        {
            currentGlitches = value;
        }
    }

    public void SetUpPlayerGlitch(InputDevice id,  Rigidbody2D rigb)
	{
		rb = rigb;
		inputDev = id;
	}



	private void ResetGlitch(bool grounded)
	{
		if (grounded)
		{
			glitchTimer = 0;
			playerGlitchState = GlitchState.canGlitch;
		}
		rb.constraints = RigidbodyConstraints2D.None;
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
	}

	public void UpdatePlayerGlitch(bool grounded)
	{
        if (playerGlitchState == GlitchState.glitching)
        {
            glitchIcon.SetActive(false);
            glitchCol.SetActive(true);
            playerGlitchState = GlitchState.glitching;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            if (grounded)
            {
                glitchTimer += Time.deltaTime;
                if (glitchTimer > 0.15f)
                    ResetGlitch(grounded);
            }
            if (InputDev.RightBumper.WasPressed)
            {
                SetGlitchState();
            }
        }
        else if (playerGlitchState == GlitchState.canGlitch)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            glitchIcon.SetActive(true);
            glitchCol.SetActive(false);
            if (InputDev.RightBumper.WasPressed)
            {
                if (currentGlitches <= maxGlitches)
                {
                    playerGlitchState = GlitchState.glitching;
                    if (!grounded)
                        currentGlitches++;
                }
                else if (grounded)
                    playerGlitchState = GlitchState.glitching;
                else
                    playerGlitchState = GlitchState.cantGlitch;
            }
        }
        else
        {
            glitchCol.SetActive(false);
            //ResetGlitch(grounded);
            rb.constraints = RigidbodyConstraints2D.None;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (currentGlitches<maxGlitches)
            {
                playerGlitchState = GlitchState.canGlitch;
            }
        }

	}

	public string WhatGlitchState()
	{
		if (playerGlitchState == GlitchState.canGlitch)
			return "canGlitch";
		else if (playerGlitchState == GlitchState.glitching)
			return "glitching";
		else
			return "cantGlitch";
	}

	public void SetGlitchState()
	{
        if (currentGlitches <= maxGlitches)
            playerGlitchState = GlitchState.canGlitch;
        else
            playerGlitchState = GlitchState.cantGlitch;
    }

    public void ResetGlitchStructure(int setGlitch)
    {
        currentGlitches = 0;
        maxGlitches = setGlitch;
    }
}
