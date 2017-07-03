using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJS : MonoBehaviour
{

    public float maxMoveSpeed;
    public float jumpForce;
    private float moveSpeedLeft;
    private float moveSpeedRight;

    private bool isJumping;

    public bool isOnGround;
    public LayerMask whatIsGround;
    public Transform checkGround;
    public float checkGroundRadius;

    private Collider2D myCollider;

    private Rigidbody2D myRigitBody;

    private Animator myAnimator;

    private bool endedMovInJump;

    public GameManagerJS gameManagerJS;


    // Use this for initialization
    void Start()
    {

        myRigitBody = GetComponent<Rigidbody2D>();
        //myCollider = GetComponent<Collider2D>();
        myAnimator = GetComponent<Animator>();
        moveSpeedLeft = 0;
        moveSpeedRight = 0;

    }

    // Update is called once per frame
    void Update()
    {

        isOnGround = Physics2D.OverlapCircle(checkGround.position, checkGroundRadius, whatIsGround);
        if (isOnGround)
        {
            if (endedMovInJump)
            {
                myRigitBody.velocity = new Vector2(0, myRigitBody.velocity.y);
                endedMovInJump = false;
                moveSpeedLeft = 0;
                moveSpeedRight = 0;
            }
            myRigitBody.velocity = new Vector2(myRigitBody.velocity.x, jumpForce);
        }


        if (Input.touchCount > 0)
        {


            if (Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                endedMovInJump = false;
                Debug.Log("touched");
                

                if (Input.GetTouch(0).position.x > 960)
                {
                    moveSpeedLeft = 0;
                    if (moveSpeedRight < maxMoveSpeed)
                    {
                        moveSpeedRight += 0.1f;
                    }
                    myRigitBody.velocity = new Vector2(moveSpeedRight, myRigitBody.velocity.y);
                    Debug.Log("right");

                }
                else
                {
                    moveSpeedRight = 0;
                    if (moveSpeedLeft < maxMoveSpeed)
                    {
                        moveSpeedLeft += 0.1f;
                    }
                    myRigitBody.velocity = new Vector2(-moveSpeedLeft, myRigitBody.velocity.y);
                    Debug.Log("Left");
                }

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                if (!isOnGround)
                {
                    endedMovInJump = true;
                    Debug.Log("ended move");
                }
                else
                {
                    endedMovInJump = false;
                }

            }

            

           
        }


        myAnimator.SetBool("IsOnGround", isOnGround);
    }

    /*
	 * Predefined unity function, used to recognize if 2 colliders touch each other
	 * Here: if player falls down and dies
	 */
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "killbox")
        {
            Debug.Log("Player dead");                           //Console shows Player dead
            gameManagerJS.RestartGame();                          //Restart method from GameManager
            moveSpeedLeft = 0;
            moveSpeedRight = 0;//reset the moveSpeed        
        }

        else if(other.gameObject.tag == "WinBox")
        {
            gameManagerJS.finishGame();
            moveSpeedRight = 0;
            moveSpeedLeft = 0;
        }
    }
}