using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{


    public GameObject bulletPowerUp;
    public GameObject lifePowerUp;

    private List<GameObject> powerUps;
    private readonly System.Random rnd = new System.Random();
    public float powerUpDuration = 10f;
    private float time;
    private GameObject activeGameObject;

    // Start is called before the first frame update
    void Start()
    {

        powerUps = new List<GameObject>
        {
            bulletPowerUp,
            lifePowerUp
        };
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (activeGameObject != null)
        {
            time = 0.0f;
            return;
        }
        if (time >= powerUpDuration)
        {
            time = 0.0f;

            GameObject powerUp = GetRandomPowerUp();
            SpawnGameObject(powerUp);
        }
    }


    private void SpawnGameObject(GameObject powerUp)
    {
        float x = Random.Range(-12f, 4f);
        float y = Random.Range(-1.5f, 3.3f);
        Vector3 position = new Vector3(x, y, 0f);
        Quaternion rotation = powerUp.transform.rotation;
        activeGameObject = Instantiate(powerUp, position, rotation);
        Debug.Log(x);
    }

    private GameObject GetRandomPowerUp()
    {
        int randomIndex = rnd.Next(powerUps.Count);
        return powerUps[randomIndex];
    }


}