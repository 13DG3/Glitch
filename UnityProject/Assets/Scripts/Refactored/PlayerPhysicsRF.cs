using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysicsRF : MonoBehaviour {
    [SerializeField]
    private LayerMask whatIsGround;
    [SerializeField]
    private LayerMask playerHead;
    private CircleCollider2D bodyCol;
    private BoxCollider2D headCol;
	[SerializeField]
	private GameObject particleEffect;
	private Rigidbody2D rb;

	private float maxFallingVelocity;

    private bool grounded;
    public bool Grounded
    {
        get
        {
            return grounded;
        }
    }
    private bool headGrounded;
    public bool HeadGrounded
    {
        get
        {
            return headGrounded;
        }
    }

	public void SetUpPhysics(BoxCollider2D bc, CircleCollider2D cc, Rigidbody2D rigb)
	{
		headCol = bc;
		bodyCol = cc;
		rb = rigb;
	}
	public void UpdatePlayerPhysics()
	{
		grounded = Physics2D.IsTouchingLayers(bodyCol, whatIsGround);
		headGrounded = Physics2D.IsTouchingLayers(bodyCol, playerHead);
		//LandingVelocity ();
		//CreateParticleEffect();
		if(!headGrounded)
			headGrounded = Physics2D.IsTouchingLayers(headCol, playerHead);
	}
	public bool AreFeetGrounded()
	{
		if (grounded || headGrounded)
			return true;
		else
			return false;
	}

	private void LandingVelocity()
	{
		if (GetComponent<Rigidbody2D> ().velocity.y < 0)
			print (GetComponent<Rigidbody2D> ().velocity.y);
	}

	private void CreateParticleEffect()
	{
		if (rb.velocity.y < maxFallingVelocity)
			maxFallingVelocity = rb.velocity.y;
		if (grounded ) 
		{
			if (maxFallingVelocity < -22) 
			{
				GameObject temp = Instantiate (particleEffect, transform.position - new Vector3(0, transform.localScale.y*2,0), Quaternion.identity);
				temp.GetComponent<ParticleEffectLanding>().ParticleSize = 100f;
			}
			maxFallingVelocity = 0;
		}
	}
}
