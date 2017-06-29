using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerJS : MonoBehaviour {

    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D myRigitBody;


	// Use this for initialization
	void Start () {

        myRigitBody = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {


       // myRigitBody.velocity = new Vector2(myRigitBody.velocity.x, jumpForce);

        if (Input.touchCount > 0)
        {


            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {


                if (Input.GetTouch(0).position.x > 960)
                {

                    Debug.Log("right");

                }
                else
                {

                    Debug.Log("left");
                }
            
            }

        }
		
	}
}
