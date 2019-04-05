using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public float spawnTime= 0.5f;
    public int scorekeep = 0;
    public int health = 10;
    public Text score,Health;
    Vector3 spawnHere;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scorekeep;
        Health.text = "Health: " + health;
        if (health <= 0)
        {
            Application.Quit();
        }
    }

    void Spawn()
    {
        spawnHere.x = Random.Range(-10, 10f);

        spawnHere.y = Random.Range(0 , 5.5f);

        spawnHere.z = 0;

        Instantiate(enemy, transform.position=spawnHere,transform.rotation);

    }
}
