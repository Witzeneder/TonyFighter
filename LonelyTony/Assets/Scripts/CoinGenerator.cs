using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour {

	public PlatformReuse coinReuse;

	public float coinSpacing;

	private int numberOfCoins;


	public void  GenerateCoins(Vector3 Position) {

		numberOfCoins = Random.Range (0, 2);


		if (numberOfCoins > 0) {
			GameObject coin = coinReuse.GetReuseablePlatform ();
			coin.transform.position = Position;
			coin.SetActive (true);
		}

		if (numberOfCoins > 1) {
			GameObject coin1 = coinReuse.GetReuseablePlatform ();
			coin1.transform.position = new Vector3 (Position.x - coinSpacing, Position.y, Position.z);
			coin1.SetActive (true);

		}
	}


}
