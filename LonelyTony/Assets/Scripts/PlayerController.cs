using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

	public float moveSpeed;						//Speed of the Player
	public float jumpForce;					//Jump Height of the Player

	private Rigidbody2D myRigidbody;		//Object this script is working with
    private Animator animator;
    private bool facesRight;

    public GameObject Bullet_Emitter;
    public GameObject Bullet;
    public float Bullet_Force;
    public float reloadTime = 2.5f;
    private float bulletReloadTime;

	//-------------------------------------------------------------------------------------------------------//

	// Use this for initialization
	void Start () {

        if (!isLocalPlayer)
        {
            return;
        }

        facesRight = true;
        myRigidbody = GetComponent<Rigidbody2D> (); //Get the Player Object
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isLocalPlayer)
        {
            return;
        }


        if (bulletReloadTime > 0f)
        {
            bulletReloadTime -= Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            bool actionProcessed = false;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
            if (hit)
            {

                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.name == "jump")
                {
                    jumpButtonClicked();
                    actionProcessed = true;
                }

                else if (hitObject.name == "shoot")
                {
                    if (bulletReloadTime < 0.01f)
                    {
                        fireShot();
                        bulletReloadTime = reloadTime;
                    }
                    actionProcessed = true;
                }
            }

            if (!actionProcessed)
            {
                if (Input.mousePosition.x > Screen.width * 0.5f)
                {
                    moveRight();
                }
                else
                {
                    moveLeft();
                }
            }

        }
        else if (transform.position.y <= -2.4f)
        {
            animator.Play("Empty_State");
        }
        else
        {
            animator.Play("Player_Jump");
        }
    }

    public void moveLeft()
    {
        if (facesRight)
        {
            myRigidbody.transform.Rotate(0f, 180f, 0f);
        }
        facesRight = false;
        myRigidbody.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        animator.Play("Player_Run");
    }

    public void moveRight()
    {
        if (!facesRight)
        {
            myRigidbody.transform.Rotate(0f, 180f, 0f);
        }
        facesRight = true;
        myRigidbody.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
        animator.Play("Player_Run");
    }

    public void jumpButtonClicked()
    {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        animator.Play("Player_Jump");
    }

    public void fireShot()
    {
        GameObject bullet = Instantiate(Bullet, Bullet_Emitter.transform.position,Bullet_Emitter.transform.rotation) as GameObject;

        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.AddForce(transform.right * Bullet_Force);
        Destroy(bullet, 1.5f);
    }
   
    /*
	 * Predefined unity function, used to recognize if 2 colliders touch each other
	 * Here: if player falls down and dies
	 */
    void OnCollisionEnter2D (Collision2D other) {
       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.name == "bulletPowerUp(Clone)")
        {
            reloadTime -= 0.5f;
            if (reloadTime < 0.5f)
            {
                reloadTime = 0.5f;
            }
            bulletReloadTime = 0f;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.name == "heart(Clone)")
        {
            //GIVE LIFE
            Destroy(collision.gameObject);
        }
    }


}


