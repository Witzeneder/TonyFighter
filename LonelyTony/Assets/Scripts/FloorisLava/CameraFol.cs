using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFol : MonoBehaviour {

	public PlayerControl player;

	private Vector3 previousPlayerPosition; // x, y, z values
	private Vector3 currentPlayerPosition; // x, y, z values

	private float moveDistance;


	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerControl> ();	// initialize player object
		previousPlayerPosition = player.transform.position;
	}

	// Update is called once per frame
	void Update () {

		currentPlayerPosition = player.transform.position;
		moveDistance = currentPlayerPosition.x - previousPlayerPosition.x;

		transform.position = new Vector3 (transform.position.x + moveDistance, transform.position.y, transform.position.z); // don't change y and z

		previousPlayerPosition = player.transform.position;

	}
}

