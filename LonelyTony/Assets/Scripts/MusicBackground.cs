using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBackground : MonoBehaviour {

	private static MusicBackground instance = null;

	public static MusicBackground Instance {
		get {
			return instance; 
		}

	}

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (this.gameObject);
			return;
		} else {
			instance = this; 	// = this scene
		}
		DontDestroyOnLoad (this.gameObject);	// --> don't destroy gameobject when a new scene is loaded
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
