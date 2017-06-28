using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform; 		//platform that is generated
	public Transform generationPoint;	//the generation point
	public float distanceBetween;		//the distance between two platforms
	private float platformWidth;		//platform width

	// Use this for initialization
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x; //get platform width
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			//get the new Position for the GenerationPoint
			transform.position = new Vector3 (transform.position.x + platformWidth + distanceBetween,
				transform.position.y, transform.position.z);											

			//Instantiate = makes a new Instant of "thePlatform" -> handles the platform generation
			Instantiate (thePlatform, transform.position, transform.rotation);

		}

	}
}
