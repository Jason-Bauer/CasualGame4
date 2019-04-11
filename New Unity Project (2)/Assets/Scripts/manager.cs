using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public GameObject powerUp;
    public float spawnTime= 0.4f;
    private float lastSpawnTime = 0.0f;
    public float powerTime = 5f;
    public int scorekeep = 0;
    public int health = 10;
    public Text score,Health;
    Vector3 spawnHere;

    void Start()
    {
        //InvokeRepeating("Spawn", spawnTime, spawnTime);
        InvokeRepeating("Powerup", powerTime, powerTime);
    }

    // Update is called once per frame
    void Update()
    {
        Spawn();
        score.text = "Score: " + scorekeep;
        Health.text = "Health: " + health;
        if (health <= 0)
        {
            Application.Quit();
        }
    }

    void Spawn()
    {
        if (Time.time > spawnTime + lastSpawnTime)
        {
            spawnHere.x = Random.Range(-10, 10f);
            spawnHere.y = Random.Range(0, 5.5f);
            spawnHere.z = 0;
            Instantiate(enemy, transform.position = spawnHere, transform.rotation);
            lastSpawnTime = Time.time;
            spawnTime = Random.Range(0.5f, 2.0f);
        }
    }

    void Powerup()
    {
        spawnHere.x = Random.Range(-10, 10f);

        spawnHere.y = Random.Range(0, 5.5f);

        spawnHere.z = 0;

        GameObject currentPowerUp;

        switch(Random.Range(0,3))
        {
            case 0:
                currentPowerUp = Instantiate(powerUp, transform.position = spawnHere, transform.rotation);
                currentPowerUp.GetComponent<PowerUp>().powerType = 0;
                break;
            case 1:
                currentPowerUp = Instantiate(powerUp, transform.position = spawnHere, transform.rotation);
                currentPowerUp.GetComponent<PowerUp>().powerType = 1;
                break;
            case 2:
                currentPowerUp = Instantiate(powerUp, transform.position = spawnHere, transform.rotation);
                currentPowerUp.GetComponent<PowerUp>().powerType = 2;
                break;
            default:
                break;
        }
    }
}
