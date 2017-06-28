using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;					//Speed of the Player
	public float speedMultiplier; 			//for speed up
	public float speedPointMultiplier;		//for variable distance for speed increase points
	public float speedUpPoint;				//distance when speed becomes increased
	private float countSpeedIncreases;		//= how often the speed has been increased


	public float jumpForce;					//Jump Height of the Player
	public float jumpTime;					//to configure the jump boost
	private float jumpTimeCounter; 			//controll the player



	//moveSpeed and jumpForce can be modified in the Player Inspector 

	private Rigidbody2D myRigidbody;		//Object this script is working with

	public bool isOnGround;
	public LayerMask whatIsGround;
	public Transform checkGround;
	public float checkGroundRadius;

	/*Used for climbing walls
	private Collider2D myCollider;
	*/

	private Animator playerAnimator;



	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> (); //Get the Player Object

		/*Used for climbing walls
		myCollider = GetComponent<Collider2D> ();	// find the collider that is attached to the object
		*/

		playerAnimator = GetComponent<Animator> ();

		jumpTimeCounter = jumpTime;

		countSpeedIncreases = speedUpPoint;			//otherwise the speed would already increase at the start

	}

	// Update is called once per frame
	void Update () {

		/*Used for climbing walls
		isOnGround = Physics2D.IsTouchingLayers (myCollider, whatIsGround); // checks if player's collider is touching ground's collider
		*/

		isOnGround = Physics2D.OverlapCircle (checkGround.position, checkGroundRadius, whatIsGround);

		if (transform.position.x > countSpeedIncreases) {					//increase speed when a speed up point has been reached

			countSpeedIncreases = countSpeedIncreases + speedUpPoint;
			speedUpPoint = speedUpPoint * speedPointMultiplier;				//speed points have to be farther apart as the player becomes faster
			moveSpeed = moveSpeed * speedMultiplier;

		}


		myRigidbody.velocity = new Vector2 (moveSpeed, myRigidbody.velocity.y); //X,Y Vector
	

		//if Space is pressed or Mouse is pressed -> Jump
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (0)) {				//Click Button

			if (isOnGround) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);
			}

		}

		if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton (0)) {						//pressed Button

			if (jumpTimeCounter > 0) {
				myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, jumpForce);		//if pressed longer you can continue jumping
				jumpTimeCounter -= Time.deltaTime;											//decrease jumpTimeCounter so it gets < 0 and stop jump
			}
		}

		if (Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0)) {					//Release Button

			jumpTimeCounter = 0;															//when stop pressing stop jumping

		}

			if(isOnGround) {																//if again on Ground reset Counter

				jumpTimeCounter = jumpTime;

			}
			
		playerAnimator.SetBool ("IsOnGround", isOnGround); // connect Animator parameter to our variable isOnGround

			}
}


