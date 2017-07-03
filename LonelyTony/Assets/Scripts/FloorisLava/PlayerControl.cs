using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float move;
	public float jump;

	private Rigidbody2D myRigidbody;
	private Animator playerAnimator;
	public float jumpTime;					//to configure the jump boost
	private float jumpTimeCounter; 			//controll the player
	private bool isJumping;					// true if player is currently in the air
	public bool isOnGround;
	public LayerMask whatIsGround;
	public Transform checkGround;
	public float checkGroundRadius;
	public GameManag gamemanag;

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();
		playerAnimator = GetComponent<Animator> ();
		jumpTimeCounter = jumpTime;
		isJumping = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		myRigidbody.velocity = new Vector2 (move, myRigidbody.velocity.y);

		isOnGround = Physics2D.OverlapCircle (checkGround.position, checkGroundRadius, whatIsGround);


		//if Space is pressed or Mouse is pressed -> Jump
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {				//Click Button
			//if (Input.touchCount > 0 ) {
			//if (Input.GetTouch (0).phase == TouchPhase.Began ) {

			if (isOnGround) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jump);
				isJumping = true;
			}

		}

		if ((Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) && isJumping) {			//pressed Button
			//if ((Input.GetTouch (0).phase == TouchPhase.Moved || Input.GetTouch (0).phase == TouchPhase.Stationary) && isJumping) {

			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jump);		//if pressed longer you can continue jumping
				jumpTimeCounter -= Time.deltaTime;											//decrease jumpTimeCounter so it gets < 0 and stop jump
			}
		}

		if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {					//Release Button
			//if (Input.GetTouch (0).phase == TouchPhase.Ended) {

			jumpTimeCounter = 0;															//when stop pressing stop jumping
			isJumping = false;

		}
		//}

		if (isOnGround) {																//if again on Ground reset Counter

			jumpTimeCounter = jumpTime;

		}


		playerAnimator.SetBool ("IsOnGround", isOnGround); // connect Animator parameter to our variable isOnGround
	
	}
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "killbox") {
			Debug.Log ("Player dead");							//Console shows Player dead
			gamemanag.RestartGame();
		
		}
	}
	}

