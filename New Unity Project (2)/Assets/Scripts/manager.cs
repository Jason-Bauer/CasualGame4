using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject enemy;
    public float spawnTime= 7f;
    
    Vector3 spawnHere;

    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        spawnHere.x = Random.Range(-10, 10f);

        spawnHere.y = Random.Range(0 , 5.5f);

        spawnHere.z = 0;

        Instantiate(enemy, transform.position=spawnHere,transform.rotation);

    }
}
