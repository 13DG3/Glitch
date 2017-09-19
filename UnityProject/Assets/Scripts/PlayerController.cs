using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerController : MonoBehaviour {
	private InputDevice joystick;
	public float moveSpeed = 0f;
	public float jumpForce;
	public float glitchJump;
	public float jumpTime;
	public float jumpTimeCounter;
	public Rigidbody2D rb;
	public bool grounded;
	public LayerMask whatIsGround;
	public LayerMask playerHead;
	public bool headGrounded;
	private CircleCollider2D myCol;
	public bool isGlitch = false;
	public bool canGlitch = false;
	public int playerInt = 0;
	public Animator anim;
	public bool facingRight = true;
	public float curTime = 0;
	public float maxTime = 0.1f;
	public GameObject glitchIcon;

	/*public float timeCounter = 0;
	public float trailTime = 0;
	public GameObject fader;
	public bool isTrailing = false;
	public SpriteRenderer mySprite;*/

	public GameObject glitchCol;
	public float curTimeCol=0;
	public float maxTimeCol = 0.1f;
	public bool glichColBool = false;
	public Camera glitchCam;
	public SpriteRenderer mySprite;

	private bool canGlitchJump  =false;
	private bool glitchJumping = false;
	private float glitchJumpTimeCounter ;
	private BoxCollider2D headCol;
	public float glitchJumpTime = 0.1f; 

	private float deathTimer;
	public float deathPeriod =1;
	public Vector3 spawnLocation;
	public bool isDead;

	// Use this for initialization
	void Start () {
		myCol = GetComponent<CircleCollider2D> ();
		headCol = GetComponent<BoxCollider2D>();
		jumpTimeCounter = jumpTime;
		joystick = InputManager.Devices[playerInt];
		curTime = 0;
		glitchCol.SetActive (false);
		glitchCam.enabled = false;
	}

	// Update is called once per frame
	void Update () {

		grounded = Physics2D.IsTouchingLayers (myCol, whatIsGround);
		if (grounded == true) {
			jumpTimeCounter = jumpTime;

			canGlitch = true;
			curTime = 0;
			rb.transform.localScale = new Vector3 (1, 1, 1);
			anim.SetBool ("isGrounded", true);

		}

		if (!grounded) {
			anim.SetBool ("isGrounded", false);
		}

		if (grounded && canGlitch == true)
			isGlitch = false;

		headGrounded = Physics2D.IsTouchingLayers(myCol, playerHead)||Physics2D.IsTouchingLayers(headCol, playerHead);
		if (headGrounded) {
			jumpTimeCounter = jumpTime;
			rb.transform.localScale = new Vector3 (1, 1, 1);
		}
		/*if (joystick.Action1 && isGlitch == false) {
			if (jumpTimeCounter > 0) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}		
		}*/

		if (joystick.Action1) {

			if (isGlitch)
			{
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
				if (canGlitchJump)
				{
					jumpTimeCounter = 0;
					canGlitchJump = false;
					glitchJumping = true;
					glitchJumpTimeCounter = glitchJumpTime;
					//rb.velocity = new Vector2(rb.velocity.x, jumpForce*1.2f);
				}
			}
			else
			{
				//if (canGlitch)
				//{
				if (jumpTimeCounter > 0)
				{
					rb.velocity = new Vector2(rb.velocity.x, jumpForce);
					jumpTimeCounter -= Time.deltaTime;
				}
				//}
			}
			isGlitch = false;
		}

		Jump();
		DeathAnimation ();

		if (joystick.Action1.WasReleased) {
			jumpTimeCounter = 0;
		}

		if (isGlitch == false && grounded) {

			rb.constraints = RigidbodyConstraints2D.None;
			rb.constraints = RigidbodyConstraints2D.FreezeRotation;
			anim.SetBool ("isGlitching", false);
			glitchIcon.SetActive (true);
			glitchCam.enabled = false;



		}
		if (isGlitch == false && !grounded) {
			curTime += 1 * Time.deltaTime;
			anim.SetBool ("isGlitching", false);
			glitchCam.enabled = false;
			if (curTime >= maxTime) {
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;

				curTime = 0;
			}
			//glitchIcon.SetActive (true);
		}






		if (joystick.RightBumper && canGlitch) {
			isGlitch = true;
			canGlitchJump = true;
			if (canGlitch && isGlitch) {
				rb.constraints = RigidbodyConstraints2D.FreezeAll;
				jumpTimeCounter = jumpTime;
				glitchIcon.SetActive (false);
				glitchCam.enabled = true;
			} 

			canGlitch = false;

		} 

		if(isGlitch)
			anim.SetBool ("isGlitching", true);


		if (joystick.RightBumper.WasPressed) {
			glichColBool = true;
			glitchCol.SetActive (true);
		}

		if (glichColBool == true) {
			curTimeCol += 1 * Time.deltaTime;
		}

		if (curTimeCol >= maxTimeCol) {
			glitchCol.SetActive (false);
			curTimeCol = 0f;
			glichColBool = false;
		}


		/*if (isTrailing) {
			timeCounter += Time.deltaTime;
			if (timeCounter >= trailTime) {
				timeCounter = 0;
				GameObject f = Instantiate (fader, new Vector3 (transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.identity) as GameObject;
				SpriteRenderer faderSprite = f.GetComponent<SpriteRenderer> ();
				faderSprite.sprite = mySprite.sprite;
			}
		}

		if (facingRight) {
			anim.SetBool ("isFacingRight", true);
		}

		if (!facingRight) {
			anim.SetBool ("isFacingRight", false);
		}*/



	}

	void FixedUpdate(){
		float x = joystick.LeftStickX * moveSpeed;


		rb.velocity = new Vector2 (x, rb.velocity.y);

		if (joystick.Action1.WasPressed) {
			if (grounded == true || headGrounded == true) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
			}
		}

		if (grounded && joystick.LeftStickX > 0.1f ||grounded && joystick.LeftStickX < -0.1f) {
			anim.SetBool ("isWalk", true);
		} else {
			anim.SetBool ("isWalk", false);
		}

		if (x > 0 && !facingRight) {
			Flip ();
			mySprite.flipX = false;

		}
		else if  (x < 0 && facingRight){
			print ("Flip");
			Flip ();
			mySprite.flipX = true;
		}

		/*anim.SetFloat ("Forward", x);
		anim.SetFloat ("Backward", x);*/
	}

	void Flip()
	{
		facingRight = !facingRight;


		/*Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;*/
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "MovingPlatform") {
			transform.parent = col.transform;
		}
	}


	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}

	void Jump()
	{
		if (glitchJumping)
		{
			if (glitchJumpTimeCounter > 0)
			{
				rb.velocity = new Vector2(rb.velocity.x, jumpForce);
				glitchJumpTimeCounter -= Time.deltaTime;
			}
			else
				glitchJumping = false;
		}
	}

	public void DeathAnimation ()
	{
		if (isDead) 
		{
			deathTimer += Time.deltaTime;
			rb.constraints = RigidbodyConstraints2D.FreezeAll;
			myCol.enabled = false;
			headCol.enabled = false;
			anim.SetBool ("isDead", true);
			if (deathTimer > deathPeriod) 
			{
				gameObject.transform.position = spawnLocation;
				isDead = false;
				myCol.enabled = true;
				headCol.enabled = true;
				rb.constraints = RigidbodyConstraints2D.None;
				rb.constraints = RigidbodyConstraints2D.FreezeRotation;
				anim.SetBool ("isDead", false);
				deathTimer = 0;
			}
		}
	}

}
