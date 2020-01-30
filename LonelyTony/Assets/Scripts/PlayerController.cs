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

    public Transform Bullet_Emitter;
    public GameObject bulletPrefab;
    public Vector2 bulletForce;
    public Vector2 bulletOffset = new Vector2(0.4f, 0.1f);
    private bool canShoot = true;
    public float Bullet_Force;
    public float reloadTime = 2.5f;
    private float bulletReloadTime;
    
    public const int maxHealth = 10;
    [SyncVar(hook = "OnChangeHealth")]
    public int currentHealth = maxHealth;

    public GameObject healthBar;
    

	//-------------------------------------------------------------------------------------------------------//

	// Use this for initialization
    private void Start ()
    {

        myRigidbody = GetComponent<Rigidbody2D>(); //Get the Player Object

        if (myRigidbody.position.x > 0)
        {
            myRigidbody.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }
        
        if (!isLocalPlayer)
        {
            return;
        }


        
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    private void Update()
    {

        if (myRigidbody.velocity.x > 0.0f)
        {
            myRigidbody.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (myRigidbody.velocity.x < 0.0f)
        {
            myRigidbody.transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        }


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
                        //fireShot();
                        CmdFire();
                        bulletReloadTime = reloadTime;
                    }
                    actionProcessed = true;
                }
            }

            if (!actionProcessed)
            {
                if (Input.mousePosition.x > Screen.width * 0.5f)
                {
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }

        }
        else if (myRigidbody.transform.position.y <= -2.4f)
        {
            animator.Play("Empty_State");
        }
        else
        {
            animator.Play("Player_Jump");
        }
    }

    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        healthBar.GetComponent<SpriteRenderer>().color = Color.green;
    }

    public void MoveLeft()
    {
        myRigidbody.AddForce(Vector2.left * moveSpeed * Time.deltaTime * 60);
        animator.Play("Player_Run");
    }

    public void MoveRight()
    {
        myRigidbody.AddForce(Vector2.right * moveSpeed * Time.deltaTime * 60);
        animator.Play("Player_Run");
    }

    public void jumpButtonClicked()
    {
        myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, jumpForce);
        animator.Play("Player_Jump");
    }



    [Command]
    private void CmdFire()
    {
        //TODO: play fire sound
        
        //TODO: modify damage
        
        //TODO: set other properties like bouncy

        GameObject bullet = Instantiate(bulletPrefab, Bullet_Emitter.position, Bullet_Emitter.rotation);
        
        bullet.GetComponent<Bullet>().Config(gameObject, 1, false, 3f);
        bullet.GetComponent<Rigidbody2D>().velocity = bulletForce.x * transform.right;
        NetworkServer.Spawn(bullet);
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

    public void TakeDamage(int amount)
    {

        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
             
        Debug.Log("health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("dead: " + currentHealth);
        }
        
       
    }

    void OnChangeHealth(int health)
    {
         //TODO: update healthbar
         healthBar.transform.localScale = new Vector2(health / 10f, healthBar.transform.localScale.y);
         
    }

}


