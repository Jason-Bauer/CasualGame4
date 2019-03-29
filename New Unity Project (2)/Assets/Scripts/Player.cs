using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigBod;
    public float speed;
    public float fireRate;
    private float lastShot = 0.0f;
    public GameObject bullet;
    public GameObject bulletSpawn;
    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {
        rigBod = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void updatehealth()
    {
        manager.GetComponent<manager>().health--;
    }
    private void Move()
    {
        //Position checks
        if (transform.position.x >= 10.0f)
        {
            transform.position = new Vector3(10.0f, transform.position.y, 0.0f);
        }
        if (transform.position.x <= -10.0f)
        {
            transform.position = new Vector3(-10.0f, transform.position.y, 0.0f);
        }
        if (transform.position.y <= -5.5f)
        {
            transform.position = new Vector3(transform.position.x, -5.5f, 0.0f);
        }
        if (transform.position.y >= 5.5f)
        {
            transform.position = new Vector3(transform.position.x, 5.5f, 0.0f);
        }

        //Movement key checks
        if (Input.GetKey(KeyCode.W))
        {
            rigBod.AddForce(Vector3.up * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigBod.AddForce(Vector3.left * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigBod.AddForce(Vector3.down * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigBod.AddForce(Vector3.right * Time.deltaTime * speed);
        }
    }

    private void Shoot()
    {
        //If it's time to shoot, then shoot!
        if (Time.time > fireRate + lastShot)
        {
            GameObject instance = Instantiate(bullet, bulletSpawn.transform);
            instance.GetComponent<Rigidbody>().velocity = new Vector3(0.0f,1.0f,0.0f) * Time.deltaTime * 2000.0f;
            lastShot = Time.time;
        }
    }
}
