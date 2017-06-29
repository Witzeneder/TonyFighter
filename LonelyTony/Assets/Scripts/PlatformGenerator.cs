using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform; 			//platform that is generated
	public Transform generationPoint;		//the generation point
	private float distanceBetween;			//the distance between two platforms
	private float platformWidth;			//platform width

	public float distanceMin;				//minimal distance
	public float distanceMax;				//maximal distance

	public PlatformReuse platfReuse;		//Instance of PlatformReuse

	private int platformSelector;			//chooses the platform with a random number
	private float[] platformWidths;		
	public PlatformReuse[] reusePlatforms;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxChange;					//need a maximum number of Change 
	private float heightChange;

	public CoinGenerator myCoinGenerator;
	public float randomCoinThreshold;


	// Use this for initialization
	void Start () {
		platformWidths = new float[reusePlatforms.Length];

		for (int i = 0; i < reusePlatforms.Length; i++) {
			platformWidths [i] = reusePlatforms [i].platform.GetComponent<BoxCollider2D> ().size.x;		//gets the widths of the different platforms
		}//end for

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		myCoinGenerator = FindObjectOfType<CoinGenerator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			//Random Number between distanceMin & distanceMax
			distanceBetween = Random.Range (distanceMin,distanceMax);

			platformSelector = Random.Range (0, reusePlatforms.Length);

			heightChange = transform.position.y + Random.Range (maxChange, -maxChange);

			if (heightChange > maxHeight) {							//keeping the platforms in the screen
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			//get the new Position for the GenerationPoint
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2 ) + distanceBetween,
				heightChange, transform.position.z);											


			GameObject newPlatform = reusePlatforms[platformSelector].GetReuseablePlatform();	//get a platform that is inactive and reuse it
			newPlatform.transform.position = transform.position;								//add current position to that platform
			newPlatform.transform.rotation = transform.rotation;								//because it was instantiated without rotation
			newPlatform.SetActive(true);														//make the platform visible now


			if (Random.Range (0f, 10f) < randomCoinThreshold) {
				myCoinGenerator.GenerateCoins (new Vector3 (transform.position.x, transform.position.y + 1f, 20));
			}

			//Generation point gets put in front of the platform
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector] / 2 ),
				transform.position.y, transform.position.z);
		}

	}
}
