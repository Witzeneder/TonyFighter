using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestruction;

	// Use this for initialization
	void Start () {

		//Find the PlatformDestructionPoint --> finds it by name in the Object's
		platformDestruction = GameObject.Find ("PlatformDestructionPoint");

		
	}
	
	// Update is called once per frame
	void Update () {

		//if transform position is past the PlatformDestructionPoint
		if (transform.position.x < platformDestruction.transform.position.x) {

			Destroy (gameObject);
		}
		
	}
}
