using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformReuse : MonoBehaviour {

	public GameObject platform;				
	public int numberOfPlatforms;	
	List<GameObject> listOfPlatforms;



	// Use this for initialization
	void Start () {

		listOfPlatforms = new List<GameObject> ();

		for (int i = 0; i < numberOfPlatforms; i++) {					//Adds all platforms to our List

			GameObject platf = (GameObject)Instantiate (platform);		//Create platform object - cast necessery for matching generic type of List
			platf.SetActive(false);										//Deactivate the new platform - activate later
			listOfPlatforms.Add(platf);

		}//end for
	}

	public GameObject GetReuseablePlatform() {

		for (int i = 0; i < listOfPlatforms.Count; i++) {				//Cycle through list and look for an inactive platform to be reused
			if (!listOfPlatforms [i].activeInHierarchy) {				//Only reuse objects that are inactive
				return listOfPlatforms[i];
			}//end if
		}//end for


		//create new platform if no inactive one has been found in the list
		GameObject platf = (GameObject)Instantiate (platform);		//Create platform object - cast necessery for matching generic type of List
		platf.SetActive(false);										//Deactivate the new platform - activate later
		listOfPlatforms.Add(platf);
		return platf;

	}//end method

}
